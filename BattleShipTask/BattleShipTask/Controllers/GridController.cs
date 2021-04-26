using BattleShip.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShipTask.Controllers
{
    public class GridController : Controller
    {
        [Route("gridinfo")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Grid()
        {
            Grid grid = new Grid();
            grid.Init();
            HttpContext.Session.SetString("GridSession", JsonConvert.SerializeObject(grid));

            return Json(grid);
        }
        [Route("gridinfo2")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Grid2()
        {
            Grid grid = new Grid();
            grid.Init();
            HttpContext.Session.SetString("GridSession2", JsonConvert.SerializeObject(grid));

            return Json(grid);
        }

        [Route("nextshotgridinfo")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult NextShot()
        {
            Grid grid = JsonConvert.DeserializeObject<Grid>(HttpContext.Session.GetString("GridSession"));
            if(grid.hitSquares.Count != 100)
            {
                grid.shot();
                grid.CheckGameOver();
            }
            HttpContext.Session.SetString("GridSession", JsonConvert.SerializeObject(grid));

            return Json(grid);
        }
        [Route("nextshotgridinfo2")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult NextShot2()
        {
            Grid grid = JsonConvert.DeserializeObject<Grid>(HttpContext.Session.GetString("GridSession2"));
            if (grid.hitSquares.Count != 100)
            {
                grid.shot();
                grid.CheckGameOver();
            }
            HttpContext.Session.SetString("GridSession2", JsonConvert.SerializeObject(grid));

            return Json(grid);
        }
    }
}
