using Core.Common.Dto;
using Core.Polling.UseCases.Constituency;
using Infrastructure.Messaging.RabbitMQ.Publisher;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll.WebApp.BaseComponents
{
    public class BallotBase : ComponentBase
    {
        [Parameter]
        public string id { get; set; }

        public ConstituencyDto ConstituencyDto { get; set; }
        public List<VotesDto> votes { get; set; } = new List<VotesDto>();


        [Inject]
        public IConstituencyService ConstituencyService { get; set; }

        [Inject]
        public IMessagePublisher MessagePublisher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ConstituencyDto = await ConstituencyService.GetCandidatesListForConstituency(Convert.ToInt64(id));
           // MessagePublisher.
        }
    }
}
