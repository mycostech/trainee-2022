using Xunit;
using todoapp_api_test.Utils;
using todoapp_api.Controllers;

namespace todoapp_api_test
{
    public class UnitTest1
    {
        [Fact]
        public void AuthController_UserRegister_ReturnsOkResult_WhenModelParametersIsValid()
        {
            var dbContext = MockDB.CreateDatabase("UserRegister");
            
        }
    }
}