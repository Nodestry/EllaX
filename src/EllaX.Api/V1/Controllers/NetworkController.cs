﻿using System.Threading.Tasks;
using EllaX.Core.Dtos;
using EllaX.Logic.Services.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace EllaX.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class NetworkController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public NetworkController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet("health")]
        [ProducesResponseType(typeof(NetworkHealthResultDto), 200)]
        public async Task<NetworkHealthResultDto> GetHealthAsync()
        {
            NetworkHealthResultDto response = await _statisticsService.GetNetworkHealthAsync<NetworkHealthResultDto>();

            return response;
        }
    }
}
