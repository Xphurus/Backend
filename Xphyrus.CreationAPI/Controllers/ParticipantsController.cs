﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xphyrus.AssesmentAPI.Data;
using Xphyrus.AssesmentAPI.Models;
using Xphyrus.AssesmentAPI.Models.Dto;
using Xphyrus.AssesmentAPI.Models.ResReq;
using Xphyrus.AssesmentAPI.Service.IService;


namespace Xphyrus.AssesmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly ApplicatioDbContext _applicationDbContext;
        private ResponseDto _responseDto;
        private IMapper _mapper;
        private readonly IAuthService _authService;
        public ParticipantsController(ApplicatioDbContext applicatioDbContext, IMapper mapper, IAuthService authService)
        {
            _applicationDbContext = applicatioDbContext;
            _responseDto = new ResponseDto();
            _mapper = mapper;
            _authService = authService;
        }

        //feels wrong
        //[HttpPost("CreateParticipantAssesment")]
        //private async Task<ActionResult<ResponseDto>> CreateParticipantAssesment(AssesmentParticipantDto assesmentParticipantDto)
        //{
        //    AssesmentParticipant assesmentParticipant = new AssesmentParticipant()
        //    {
        //        ApplicationUser = assesmentParticipantDto.ApplicationUserEmail,
        //        AssesmentId = assesmentParticipantDto.AssesmentId,
        //        HasCompleted = false,
        //        HasStarted = false,
        //    };
        //    await _applicationDbContext.AssesmentParticipants.AddAsync(assesmentParticipant);
        //    await _applicationDbContext.SaveChangesAsync();
        //    _responseDto.Result = true;
        //    return _responseDto;
        //}
        //invoked by auth
        [HttpPost("Register")]
        //check code
        //check if registers already
        //regisre
        public async Task<ActionResult<ResponseDto>> RegisterForAssesment(string AssesmentCode)
        {
          
            Assesment? assesment = _applicationDbContext.Assesments.FirstOrDefault(u => u.Code == AssesmentCode);
            if (assesment == null)
            {   
                _responseDto.IsSuccess = false;
                _responseDto.Message = "cant find that assemsnt";
                return _responseDto; 
            }
            AssesmentParticipant assesmentParticipant = new AssesmentParticipant()
            {
                ApplicationUser = "a",
                AssesmentId = assesment.AssesmentId,
                HasCompleted = false,
                HasStarted = false,
            };
            await _applicationDbContext.AssesmentParticipants.AddAsync(assesmentParticipant);
            await _applicationDbContext.SaveChangesAsync();
            _responseDto.Result = true;
            


            return _responseDto;
        }
        [HttpPost("Start")]
        public async Task<ActionResult<ResponseDto>> StartAssesment([FromBody] StartAssesmentDto startAssesmentDto)
        {
            try
            {
                AssesmentParticipant? assesmentParticipant = await _applicationDbContext.AssesmentParticipants.SingleOrDefaultAsync(u => (u.AssesmentId == startAssesmentDto.AssesmentCode && u.ApplicationUser == startAssesmentDto.UserEmail));
                if (assesmentParticipant == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "unable to find single";
                    return _responseDto;
                }
                if (assesmentParticipant.HasStarted == false && assesmentParticipant.HasCompleted == false)
                {
                    assesmentParticipant.HasStarted = true;
                    _applicationDbContext.AssesmentParticipants.Update(assesmentParticipant);
                    await _applicationDbContext.SaveChangesAsync();
                    _responseDto.IsSuccess = true;
                    _responseDto.Result = assesmentParticipant;
                    return _responseDto;
                }
                _responseDto.IsSuccess = false;
                _responseDto.Message = "already started or submitted";
                return _responseDto;


            }
            catch (Exception ex)
            {

                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
        [HttpPost("Submit")]
        public async Task<ActionResult<ResponseDto>> Submit([FromBody] SubmissionDto submissionDto)
        {
            try
            {
                AssesmentParticipant? assesmentParticipant = await _applicationDbContext.AssesmentParticipants.SingleOrDefaultAsync(u => (u.AssesmentId == submissionDto.AssesmentId && u.ApplicationUser == submissionDto.UserEmail));
                if (assesmentParticipant == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "didnt registered or unable to find single";
                    return _responseDto;
                }
                if (assesmentParticipant.HasStarted == true && assesmentParticipant.HasCompleted == false)
                {
                    assesmentParticipant.HasCompleted = true;
                    _applicationDbContext.AssesmentParticipants.Update(assesmentParticipant);
                    await _applicationDbContext.SaveChangesAsync();
                    _responseDto.IsSuccess = true;
                    return _responseDto;
                }
                _responseDto.IsSuccess = false;
                _responseDto.Message = "already started or submitted";
                return _responseDto;
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
