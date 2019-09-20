using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Controllers.GraphQL;
using GraphQL_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_Demo.Controllers
{
    [Route("graphql/all")]
    [ApiController]
    public class RetriveListController : ControllerBase
    {
        private readonly MyDBContext _context;

        public RetriveListController(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new AllUsersQuery(_context)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}