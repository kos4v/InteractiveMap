using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveMap.Models
{
    public static class MapInfo
    {
        public static Map GetMap(int MapId)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            return  _context.Maps.Find(MapId);
        }
        public static Layer [] GetLayers(int MapId)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            return _context.Layers.Where(m=>m.MapId == MapId).ToArray();
        }
        public static LayerDot[] GetLayerDots(int MapId)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            return _context.LayerDots.Where(m => m.MapId == MapId).ToArray();
        }
    }
    public class Map
    {
        [Key]
        public int Id { get; set; }
        public List<Layer> Layers { get; set; }
    }
}
