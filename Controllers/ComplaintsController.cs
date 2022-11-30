using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;



namespace WebApplication2.Controllers
{
    //добавление жалобы на отзыв и обновление жалобы
    [Route("review/complaint")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private ComplaintContext _complaintContext;

        public ComplaintsController(ComplaintContext complaintContext)
        {
            _complaintContext = complaintContext;
        }

        [HttpPost]
        public async Task AddComplaint([FromBody] Dictionary<string, object> ComplaintAddRxData)
        {
            //try {
            Complaint newComplaint = new Complaint
            {
                //id = Convert.ToInt32(ComplaintAddRxData["id"]),
                idReview = Convert.ToInt32(ComplaintAddRxData["idReview"]),
                complaint = ComplaintAddRxData["complaint"].ToString(),
                idUser = Convert.ToInt32(ComplaintAddRxData["idUser"]),
                contact = ComplaintAddRxData["contact"].ToString(),
                active = true,
                //active = bool.Parse(ComplaintAddRxData["active"].ToString()),
                dateCreate = ComplaintAddRxData["dateCreate"].ToString()
            };
            await _complaintContext.complaints.AddRangeAsync(newComplaint);
            await _complaintContext.SaveChangesAsync();
            //return ("ok");
            // }
            // catch(Exception ex)
            // {
            //   return (ex.Message);
            //}

        }


        [HttpPut]
        public async Task RefreshComplaint([FromBody] Dictionary<string, object> ComplaintRefRxData)
        {
            Complaint complaintById = _complaintContext.complaints.Where(c => c.idReview == Convert.ToInt32(ComplaintRefRxData["idReview"])).FirstOrDefault();

            complaintById.complaint = ComplaintRefRxData["complaint"].ToString();
            complaintById.idUser = Convert.ToInt32(ComplaintRefRxData["idUser"]);
            complaintById.contact = ComplaintRefRxData["contact"].ToString();
            complaintById.active = bool.Parse(ComplaintRefRxData["active"].ToString());

            await _complaintContext.SaveChangesAsync();
        }
    }

    //список жалоб на комментарии
    [Route("review/complaint/list")]
    [ApiController]
    public class ComplaintListController : ControllerBase
    {
        private ComplaintContext _complaintContext;

        public ComplaintListController(ComplaintContext complaintContext)
        {
            _complaintContext = complaintContext;
        }

        [HttpPost]
        public async Task<string> ComplaintList()
        {
            var cm = _complaintContext.complaints.Where(c => c.active == true);
            //var complaints = _complaintContext.complaints.ToList();

            var jsonResult = JsonConvert.SerializeObject(cm);
            return $"{jsonResult}";
        }

    }
}