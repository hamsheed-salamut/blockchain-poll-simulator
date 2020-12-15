using Core.Common.Dto;
using Dapper;
using Infrastructure.Blockchain;
using Infrastructure.Blockchain.Models;
using Infrastructure.Persistence.Mssql;
using Infrastructure.Persistence.Mssql.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Polling.Repositories
{
    public class PollingRepository : BaseRepository<VotesEntry>, IPollingRepository
    {
        public PollingRepository(MsSqlDbOptions msSqlDbOptions) : base(msSqlDbOptions)
        {

        }
        public async Task<List<CandidateDto>> GetCandidatesListForConstituency(long constituencyId)
        {
            string query = @"SELECT     candidate.CandidateId,
                                        candidate.FirstName,
                                        candidate.LastName,
                                        candidate.Aka,
                                        candidate.Occupation,
                                        candidate.Address,
                                        candidate.PartyId,
                                        party.PartyName,
                                        party.Abbr as PartyAbbr,
                                        party.PartyLogo as PartyEmblem,
                                        party.ActualAlliance,
                                        constituency.ConstituencyId,
                                        constituency.ConstituencyName,
                                        election.ElectionName
                                    FROM
                                        dbo.Candidate candidate
                                    INNER JOIN 
                                        dbo.Constituency constituency
                                    INNER JOIN 
                                        dbo.Election election
                                    ON
                                        1 = election.ElectionId
                                    ON 
                                        candidate.ConstituencyId = constituency.ConstituencyId
                                    LEFT JOIN 
                                        dbo.Party party
                                    ON 
                                        candidate.PartyId = party.PartyId
                                    WHERE
                                        candidate.ConstituencyId = @constituencyIdParam
                                    AND
                                        candidate.ElectionId = 1";

            var result = await Connection.QueryAsync<CandidateDto>(query,
                                    new
                                    {
                                        constituencyIdParam = constituencyId
                                    });

            var candidatesForConstituency = result.OrderBy(x => x.LastName).ToList();

            return candidatesForConstituency;
        }

        public async Task CastVotes(VotesEntry votesEntry)
        {
            if (votesEntry == null)
                throw new ArgumentNullException(nameof(votesEntry));

            var query = @"SELECT 
                                *
                          FROM 
                                dbo.Votes
                          WHERE 
                          VoteEntryId = @voteEntryParam";

            var result = await Connection.QueryAsync<VotesEntry>(query,
                                    new
                                    {
                                        voteEntryParam = votesEntry.VoteEntryId
                                    });

            var votesEntries = result.ToList();

            BlockchainHelper.VerifyBlockChain(votesEntries);
            if (votesEntries.Any(v => !v.IsValid))
            {
                throw new InvalidOperationException("Blockchain was invalid");
            }

            string previousBlockHash = null;
            if (votesEntries.Any())
            {
                var previousVotesEntry = votesEntries.Last();
                votesEntry.PreviousId = previousVotesEntry.Id;
                previousBlockHash = previousVotesEntry.Hash;
            }

            var blockText = BlockHelper.ConcatData(votesEntry.VoteEntryId, votesEntry.CandidateId,
                votesEntry.CandidateName, votesEntry.PartyId, DateTime.Now, previousBlockHash);
            
            votesEntry.Hash = HashHelper.Hash(blockText);

            await AddAsync(votesEntry);
        }
    }
}
