using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechnicalTask_C_sharp_MVC.Models;
using TechnicalTask_C_sharp_MVC.MdelsDTO;
using TechnicalTask_C_sharp_MVC.RepositoryIntefaces;

namespace TechnicalTask_C_sharp_MVC.Controllers
{
    public class CommandsController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly Item _item ;
        private readonly IHttpClientFactory _clientFactory;
        public DbCommandTypesBaseQueryResult dbCommandTypesBaseQueryResult { get; set; }
       
        public CommandsController(IItemRepository itemRepository, IHttpClientFactory clientFactory, Item item)
        {
            _itemRepository = itemRepository;
            _clientFactory = clientFactory;
            _item = item;
            _item.Terminal_id = 129;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommandList()
        {
            var httpClient = _clientFactory.CreateClient();
            var URL = $"http://178.57.218.210:198/commands/types?token=pdebbd1b-8aba-434f-9bf6-";
            var response = await httpClient.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();

                dbCommandTypesBaseQueryResult = JsonConvert.DeserializeObject
                <DbCommandTypesBaseQueryResult>(responseStream);
            }
            else
            {
                dbCommandTypesBaseQueryResult = new DbCommandTypesBaseQueryResult();
            }
            var commands = dbCommandTypesBaseQueryResult.Items;

            ViewBag.Commands = new SelectList(commands, "Id", "Name");
            ViewBag.TerminalId = _item.Terminal_id;
            ViewBag.Items = _itemRepository.GetItemList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult>  CreateCommand(DbCommandTypes dbCommandTypes)
        {
            var httpClient = _clientFactory.CreateClient();
            var URL = $"http://178.57.218.210:198/commands/types?token=pdebbd1b-8aba-434f-9bf6-";
            var response = await httpClient.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();

                dbCommandTypesBaseQueryResult = JsonConvert.DeserializeObject
                <DbCommandTypesBaseQueryResult>(responseStream);
            }
            else
            {
                dbCommandTypesBaseQueryResult = new DbCommandTypesBaseQueryResult();
            }
            var commands = dbCommandTypesBaseQueryResult.Items;
            var command = commands.Find(c => c.Id == dbCommandTypes.Id);

            Item fullItem = new Item()
            {
                Terminal_id = _item.Terminal_id,
                Command_id = command.Id,
                Str_parameter1 = command.Name,
                Str_parameter2 = command.Parameter_name1,
                Parameter1 = command.Parameter_default_value1
            };

            if (dbCommandTypes.Id == 2)
            {
                ViewBag.Items = _itemRepository.GetItemList();

                return View("RestartTerminal",fullItem);
            }

            ViewBag.Items = _itemRepository.GetItemList();

            return View(fullItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommand(int commandId, int terminalId, string strParameter1, int parameter1)
        {
            Item item = new Item()
            {
                Command_id = commandId,
                Parameter1 = parameter1,
                Parameter2 = 0,
                Parameter3 = 0,
                Parameter4 = 0,
                Str_parameter1 = strParameter1,
                Str_parameter2= "string"

            };

            var httpClient = _clientFactory.CreateClient();
            var URL = $"http://178.57.218.210:198/terminals/129/commands?token=pdebbd1b-8aba-434f-9bf6-";

            var itemJson = JsonConvert.SerializeObject(item, Formatting.Indented);

            HttpContent httpContent = new StringContent(itemJson, Encoding.UTF8, "application/json");

            using var httpResponseMessage =
           await httpClient.PostAsync(URL, httpContent);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return StatusCode(500, "Something Went Wrong! Error Occured");
            }

            TeminalIdCommand teminalIdCommand = JsonConvert.DeserializeObject<TeminalIdCommand>(httpResponseMessage
                .Content.ReadAsStringAsync().Result);

            ItemDTO itemDto = new ItemDTO()
            {
                Terminal_id = teminalIdCommand.Item.Terminal_id,
                Command_id = teminalIdCommand.Item.Command_id,
                Parameter1 = teminalIdCommand.Item.Parameter1,
                Parameter2 = teminalIdCommand.Item.Parameter2,
                Parameter3 = teminalIdCommand.Item.Parameter3,
                Parameter4 = teminalIdCommand.Item.Parameter4,
                Str_parameter1 = teminalIdCommand.Item.Str_parameter1,
                State_name = teminalIdCommand.Item.State_name,
                Time_created = teminalIdCommand.Item.Time_created
            };

            _itemRepository.Create(itemDto);

            return RedirectToAction("GetCommandList","Commands");
        }

    }
}

