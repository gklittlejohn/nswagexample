using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace NSwag.Generation.AspNetCore.Tests.Web.Controllers.Requests
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumesController : Controller
    {
        /* 
         Expected: 
         "requestBody": {
          "x-name": "body",
          "content": {
            "foo/bar": {
              "schema": {
                "type": "string"
              }
            },
            "text/html": {
              "schema": {
                "type": "string"
              }
            }
          },
          "required": true,
          "x-position": 1
        
         Actual: 
         "requestBody": {
          "x-name": "body",
          "content": {
            "application/json": {
              "schema": {
                "type": "string"
              }
            }
          },
          "required": true,
          "x-position": 1
        }*/
        [Consumes("foo/bar", "text/html")] // requires CustomTextInputFormatter
        [HttpPost("ConsumesOnOperation")]
        public ActionResult ConsumesOnOperation([FromBody] string body)
        {
            return Ok();
        }

        [Consumes("text/html")]
        [HttpPost("SecondOperation")]
        public ActionResult SecondOperation([FromBody] string body)
        {
            return Ok();
        }

        /* Expected:
         "requestBody": {
          "x-name": "body",
          "content": {
            "application/json": {
              "schema": {
                "type": "string"
              }
            },
            "text/html": {
              "schema": {
                "schema": {
                "type": "string"
              }
            }
          }
          
          Actual:
          "requestBody": {
          "x-name": "body",
          "content": {
            "application/json": {
              "schema": {
                "type": "string"
              }
            },
            "text/html": {
              "schema": {
                "type": "file"
              }
            }
          }*/

        [OpenApiBodyParameter("text/html")]
        [HttpPost("ConsumesOnOperationBodyParameter")]
        public ActionResult ConsumesOnOperationBodyParameter([FromBody] string body)
        {
            return Ok();
        }
    }
}
