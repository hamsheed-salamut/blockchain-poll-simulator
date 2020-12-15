using Infrastructure.Blockchain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Blockchain
{
    public static class BlockchainHelper
    {
        public static void VerifyBlockChain(IList<VotesEntry> votesEntries)
        {
            string previousHash = null;
            foreach (var entry in votesEntries.OrderBy(c => c.Id))
            {
                var previousBlock = votesEntries.SingleOrDefault(c => c.Id == entry.PreviousId);
                var blockText = BlockHelper.ConcatData(
                    entry.VoteEntryId,
                    entry.CandidateId,
                    entry.CandidateName,
                    entry.PartyId,
                    DateTime.Now,
                    previousHash);

                var blockHash = HashHelper.Hash(blockText);

                // check current block hashes, and previous block hashes, since
                // it could have been modified in DB, ie checking the chain by two blocks at a time
                entry.IsValid = blockHash == entry.Hash && previousHash == previousBlock?.Hash;

                previousHash = blockHash;
            }
        }
    }
}
