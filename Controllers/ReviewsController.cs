using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    //добавить отзыв к кальянной
    [Route("review/add")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewContext _reviewContext;
        public HookaContext _hookaContext;


        public ReviewsController(ReviewContext reviewContext,HookaContext hookaContext)
        {
            _reviewContext = reviewContext;
            _hookaContext = hookaContext;
        }

        [HttpPost]
        public async Task<IActionResult> ReviewAdd ([FromBody] Dictionary<string, object> ReviewAddRxData)
        {
            Review addNowReview = new Review
            {
                idHookah = Convert.ToInt32(ReviewAddRxData["idHookah"]),
                idUser = Convert.ToInt32(ReviewAddRxData["idUser"]),
                comment = ReviewAddRxData["comment"].ToString(),
                //compliments = ReviewAddRxData["compliments"].ToString().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray(),
                compliments = ReviewAddRxData["compliments"].ToString(),
                rating = Convert.ToInt32(ReviewAddRxData["rating"]),
                dateCreate = ReviewAddRxData["dateCreate"].ToString()
            };

            //добавим в счетчик отзывов +1 к этой кальянной 
            Hooka hooka = _hookaContext.hookas.Where(h => h.id == addNowReview.idHookah).FirstOrDefault();
            hooka.ratingCount++;

            _reviewContext.reviews.Add(addNowReview);
            _reviewContext.SaveChanges();
            _hookaContext.SaveChanges();

            return Ok("добавление отзыва прошло успешно");
        }
    }

    //список отзывов по кальянной
    [Route("review/list/hookah/{idRes}")]
    [ApiController]
    public class ReviewListController : ControllerBase
    {
        private readonly ReviewContext _reviewContext;
        public HookaContext _hookaContext;


        public ReviewListController(ReviewContext reviewContext, HookaContext hookaContext)
        {
            _reviewContext = reviewContext;
            _hookaContext = hookaContext;
        }

        //[HttpGet("{id}", Name = "GetHookaAllReviewById")]
        [HttpGet]
        public string GetHookaAllReviewById (int idRes)
        {
            string result;
            List<Review> reviewsAllField = new List<Review>();
            Hooka hooka = _hookaContext.hookas.Where(h => h.id == idRes).FirstOrDefault();
            if(hooka.active == true)
            {
                reviewsAllField.AddRange(_reviewContext.reviews.Where(r => r.idHookah == idRes & r.active == true));
            }

            List<ReviewForHookahReviewList> resultList = new List<ReviewForHookahReviewList>();
            foreach (Review fullFieldRev in reviewsAllField)
            {
                resultList.Add(new ReviewForHookahReviewList
                {
                    id = fullFieldRev.id,
                    idUser = fullFieldRev.idUser,
                    comment = fullFieldRev.comment,
                    rating = fullFieldRev.rating,
                    dateCreate = fullFieldRev.dateCreate
                }
                );
            }

            result = JsonConvert.SerializeObject(resultList);
            return result;
        }
    }


    //удаление отзыва по id
    [Route("review/delete")]
    [ApiController]
    public class ReviewDeleteController : ControllerBase
    {
        private readonly ReviewContext _reviewContext;
        public HookaContext _hookaContext;

        public ReviewDeleteController(ReviewContext reviewContext, HookaContext hookaContext)
        {
            _reviewContext = reviewContext;
            _hookaContext = hookaContext;
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Review reviewDel = _reviewContext.reviews.Where(r => r.id == id).FirstOrDefault();
            _reviewContext.Remove(reviewDel);
            _reviewContext.SaveChanges();
        }
    }


    //обновление отзыва по кальянной
    [Route("review")]
    [ApiController]
    public class ReviewRefreshController : ControllerBase
    {
        private readonly ReviewContext _reviewContext;
        public HookaContext _hookaContext;


        public ReviewRefreshController(ReviewContext reviewContext, HookaContext hookaContext)
        {
            _reviewContext = reviewContext;
            _hookaContext = hookaContext;
        }


        [HttpPut]
        public void Refresh([FromBody] Dictionary<string, object> ReviewRefRxData)
        {
            Review reviewRef = _reviewContext.reviews.Where(r => r.id == 
                            Convert.ToInt32(ReviewRefRxData["id"])).FirstOrDefault();

            reviewRef.idUser = Convert.ToInt32(ReviewRefRxData["idUser"]);
            reviewRef.comment = ReviewRefRxData["comment"].ToString();
            reviewRef.compliments = ReviewRefRxData["compliments"].ToString();
            reviewRef.rating = Convert.ToInt32(ReviewRefRxData["rating"]);
            reviewRef.dateCreate = ReviewRefRxData["dateCreate"].ToString();
            reviewRef.active = bool.Parse(ReviewRefRxData["active"].ToString());

            _reviewContext.SaveChanges();
        }

    }



}
