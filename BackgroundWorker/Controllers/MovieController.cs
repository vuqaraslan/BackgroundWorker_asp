using BackgroundWorker.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackgroundWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly System.ComponentModel.BackgroundWorker? _backgroundWorker;
        public string? Result { get; set; }
        public MovieController()
        {
            _backgroundWorker = new System.ComponentModel.BackgroundWorker();
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

        }

        private async void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            var r_letter = RandomLetter.GiveRandomLetter();
            string apiKey = "6a7845e5"; // OMDb API açarı
            string movieTitle = $"{r_letter}"; // Axtardığınız film adı
            //string url = $"http://www.omdbapi.com/?t={movieTitle}&apikey={apiKey}";
            string url = $"http://www.omdbapi.com/?s={movieTitle}&apikey={apiKey}";

            HttpResponseMessage response = null;

            Thread.Sleep(5000);
            using (HttpClient client = new HttpClient())
            {
                response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //string result = await response.Content.ReadAsStringAsync();
                    Result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(Result);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            //string result2 = await response.Content.ReadAsStringAsync();
        }

        private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Request is finished !");
        }


        // GET: api/<MovieController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //if (!_backgroundWorker.IsBusy)
            //{
            //    await Task.Run(async () =>
            //     {
            //         _backgroundWorker.RunWorkerAsync();
            //     });
            //    return Ok(Result);
            //}
            //return BadRequest("BackgroundWorker is working also !");



            var r_letter = "Inter"; //RandomLetter.GiveRandomLetter();
            string apiKey = "6a7845e5"; // OMDb API açarı
            string movieTitle = $"{r_letter}"; // Axtardığınız film adı
            //string url = $"http://www.omdbapi.com/?t={movieTitle}&apikey={apiKey}";
            string url = $"http://www.omdbapi.com/?s={movieTitle}&apikey={apiKey}";

            HttpResponseMessage response = null;

            //Thread.Sleep(5000);
            using (HttpClient client = new HttpClient())
            {
                response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //string result = await response.Content.ReadAsStringAsync();
                    Result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(Result);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            return Ok(Result);

        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
