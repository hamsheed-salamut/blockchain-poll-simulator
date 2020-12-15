using Core.Common.Dto;
using Core.Polling.UseCases.Voter;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll.WebApp.BaseComponents
{
    public class VoterBase : ComponentBase
    {
        [Inject]
        public IVoterService VoterService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public VoterDto _VoterDto { get; set; } = new VoterDto();

        [Parameter]
        public string Nic { get; set; }

        protected async Task AuthenticateVoter()
        {
            _VoterDto = await VoterService.Authenticate(_VoterDto.Nic);

            if (_VoterDto != null)
            {
                NavigationManager.NavigateTo("/ballot/" + _VoterDto.ConstituencyId);
            }

            //UriHelper.NavigateTo("");
        }
    }
}
