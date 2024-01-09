namespace DatabaseOps.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class VidManagerController : ControllerBase
    {
        private readonly DatabaseOps _db;

        public VidManagerController(DbContextImpl dbContext)
        {
            _db = new DatabaseOps(dbContext);
        }

        // GET: api/<VidManagerController>
        [HttpGet]
        [Route("api/[controller]/Trial")]
        public IActionResult GetTrial()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                string response = "Received request!";
                return Ok(ResponseHandler.GetAppResponse(type, response));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET: api/<VidManagerController>
        [HttpGet]
        [Route("api/[controller]/GetFiles")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<FileDetailsModel> data = _db.GetFileDetails();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET: api/<VidManagerController>/GetFileById
        [HttpGet]
        [Route("api/[controller]/GetFileById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                FileDetailsModel data = _db.GetFileDetailById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<VidManagerController>/SaveNewFile
        [HttpPost]
        [Route("api/[controller]/SaveNewFile")]
        public IActionResult Post([FromBody] FileDetailsModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveNewFile(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<VidManagerController>/SaveNewVersion
        [HttpPost]
        [Route("api/[controller]/SaveNewVersion")]
        public IActionResult Post([FromBody] VersionDetailsModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveNewVersion(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<VidManagerController>/UpdateVersion
        [HttpPut]
        [Route("api/[controller]/UpdateVersion")]
        public IActionResult Put([FromBody] VersionDetailsModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateVersion(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<VidManagerController>/DeleteVersion
        [HttpDelete]
        [Route("api/[controller]/DeleteVersion/{id}")]
        public IActionResult DeleteVersion(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteVersion(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<VidManagerController>/DeleteFile
        [HttpDelete]
        [Route("api/[controller]/DeleteFile/{id}")]
        public IActionResult DeleteFile(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteFile(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
