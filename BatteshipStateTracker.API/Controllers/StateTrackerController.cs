﻿using BattleShipStateTracker.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BattleShipStateTracker.API.Models;

namespace BattleShipStateTracker.API.Controllers
{
    public class StateTrackerController : ApiController
    {
        private readonly IStateTrackerService _stateTrackerService;
        public StateTrackerController(IStateTrackerService stateTrackerService)
        {
            _stateTrackerService = stateTrackerService;
        }

        [HttpPost]
        [Route("processshot")]
        public HttpResponseMessage CreateGameBoardAndProcessShots(StateTrackerModel stateTrackerModel)
        {
            try
            {
                var shotResult = _stateTrackerService.CreateGameBoardAndProcessShots(stateTrackerModel.RowNumber, stateTrackerModel.ColumnNumber);
                return Request.CreateResponse(HttpStatusCode.OK, shotResult.ToString());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

    }
}

