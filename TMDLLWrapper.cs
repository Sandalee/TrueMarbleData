using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TrueMarbleData
{
    class TMDLLWrapper
    {
        [DllImport("TrueMarbleDLL.dll")]
        public static extern int GetTileSize(out int width, out int height);

        [DllImport("TrueMarbleDLL.dll")]
        public static extern int GetNumTiles(int zoomLevel, out int numTilesX, out int numTilesY);
        //int DllExport GetNumTiles(int zoomLevel, int *numTilesX, int *numTilesY);

        [DllImport("TrueMarbleDLL.dll")]
        public static extern int GetTileImageAsRawJPG(int zoomLevel, int tileX, int tileY, byte[] imageBuf, int bufSize, out int jpgSize);
        //int DllExport GetTileImageAsRawJPG(int zoomLevel, int tileX, int tileY, unsigned char *imageBuf, int bufSize, int *jpgSize);


        [DllImport("TrueMarbleDLL.dll")]
        public static extern int GetTileImageAsRawJPG_dbg(int zoomLevel, int tileX, int tileY, byte[] imageBuf, int bufSize, out int jpgSize, out string[] sFile, out string[] sErr); 
        //int DllExport GetTileImageAsRawJPG_dbg(int zoomLevel, int tileX, int tileY, unsigned char *imageBuf, int bufSize, int *jpgSize, char **sFile, char **sErr);

    }
}
