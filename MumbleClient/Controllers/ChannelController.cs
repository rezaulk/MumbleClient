using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mumble;
using MurmurCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MumbleClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private IMumbleServerClient _mumbleServerClient;
        public ChannelController(IMumbleServerClient mumbleClient)
        {
            _mumbleServerClient = mumbleClient;
        }


        [HttpGet]
        [Route("AllChannels")]
        public IActionResult AllChannels()
        {
            var server = _mumbleServerClient.GetMumbleIceServerInstance().GetServer(1);
            if (server == null)
            {
                throw new Exception("No Server found");
            }
            var Channels = server.GetAllChannels().ToList();
            return Ok(new { Channels });
        }

        [HttpGet]
        [Route("CreateChannel")]
        public IActionResult CreateChannel(string Channelname)
        { 
           _mumbleServerClient.GetMumbleIceServerInstance().CreateChannel(1, Channelname, 0); ;

            return Ok();
        }


        [HttpGet]
        [Route("MoveTochannel")]
        public IActionResult MoveTochannel(string Usermane,int ChannelID)
        {

           
            var server = _mumbleServerClient.GetMumbleIceServerInstance().GetServer(1);
            if (server == null)
            {
                throw new Exception("No Server found");
            }
            var onlineUser = server.GetOnlineUsers().Where(x => x.Value.Name == Usermane).FirstOrDefault();
            
            onlineUser.Value.ChannelId = ChannelID;
            var message = _mumbleServerClient.GetMumbleIceServerInstance().SetUserState(1, onlineUser.Value); 
          
            return Ok();
        }


        [HttpGet]
        [Route("Check2Channels")]
        public IActionResult GetChannels(string StatbeChannel= "Channel Twenty Four", string UnstableChannel= "NybTestChannel0")
        {


            var server = _mumbleServerClient.GetMumbleIceServerInstance().GetServer(1);
            if (server == null)
            {
                throw new Exception("No Server found");
            }
            var Channels = server.GetAllChannels().Where(x => x.Value.Name == StatbeChannel).FirstOrDefault();
            var Channel1 = server.GetAllChannels().Where(x => x.Value.Name == UnstableChannel).FirstOrDefault();



            var Channels_ =  JsonSerializer.Serialize(Channels);
            var Channels1_ = JsonSerializer.Serialize(Channel1);

            return Ok( new { Channels_, Channels1_ });
        }

    }
}
