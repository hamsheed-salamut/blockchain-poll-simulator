using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Blockchain
{
    public static class BlockHelper
    {
        public static string ConcatData(long voteEntryId, long candidateId, string candidateName, long partyId, DateTime transactionDate, string previousBlockHash)
        {
            var formattedCandidateName = candidateName.ToString();
            var formattedDate = transactionDate.ToString("yyyy-MM-dd");
            return $"{voteEntryId}{candidateId}{formattedCandidateName}{partyId}{formattedDate}{previousBlockHash}";
        }
    }
}