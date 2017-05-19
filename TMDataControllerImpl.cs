using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace TrueMarbleData
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]

    internal class TMDataControllerImpl:ITMDataController
    {
        public TMDataControllerImpl()
        {
            Console.WriteLine("New Client has connected");
        }


  
        //Gets the width of the tile using the GetTileSize() method in TMDLLWrapper class
        //if the success value is not equal to 1(i.e.,failure),throw a fault exception
        public int GetTileWidth()
        {
            int width=0;
            int height=0;
            try
            {
                int success = TMDLLWrapper.GetTileSize(out width, out height);
                if (success != 1)
                {
                    throw new FaultException();
                }
                else
                {
                    Console.WriteLine("Success GetTileWidth()!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occured in invoking the method GetTileWidth()!"+ e);
            }

            return width;

            
        }



        //Gets the height of the tile using the GetTileSize() method in TMDLLWrapper class
        //if the success value is not equal to 1(i.e.,failure),throw a fault exception
        public int GetTileHeight()
        {
            int width ; 
            int height = 0;
            try
            {
                int success = TMDLLWrapper.GetTileSize(out width, out height);
                if (success != 1)
                {
                    throw new FaultException();
                }
                else
                {
                    Console.WriteLine("Success GetTileHeight()!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occured in invoking the method GetTileHeight()!"+ e);
            }

            return height;

            //throw new NotImplementedException();
        }
        

        //Gets the number of tiles Across(X range) using GetNumTiles Method in TMDLLWrapper class
        public int GetNumTilesAcross(int zoom)
        {
            int numTileX=0;
            int numTileY;
            try
            {
                int success = TMDLLWrapper.GetNumTiles(zoom, out numTileX, out numTileY);
                if (success != 1)
                {
                    throw new FaultException();
                }
                else
                {
                    Console.WriteLine("Success GetNumTilesAcross()!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occured in invoking the method GetNumTilesAcross()!"+ e);
 
            }
            return numTileX;

            //throw new NotImplementedException();
        }

        //Gets the no.of tiles in Y range using GetNumTiles() method inn TMDLLWrapper class
        public int GetNumTilesDown(int zoom)
        {
            int numTileX=0;
            int numTileY=0;
            try
            {
                int success = TMDLLWrapper.GetNumTiles(zoom, out numTileX, out numTileY);
                if (success != 1)
                {
                    throw new FaultException();
                }
                else
                {
                    Console.WriteLine("Sucess GetNumTilesDown()!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error Occured in invoking the method GetNumTilesDown() !"+ e);

            }
            return numTileY;

            
        }



        //Get a byte array to hold JPEG data using the GetTileImageAsRawJPG() method in TMDLLWrapper class

        
        public byte[] LoadTile(int zoom, int x, int y)
        {
             
            int jpgSize;

            int width = GetTileWidth();                 //Get the width of the tile
            int height = GetTileHeight();               //Get the Height of the tile 
            int arrSize = width * height * 3;       //calculating the size of the buffer required to load the image
            byte[] imgBuffRawJpg = new byte[arrSize];  //allocating a byte array to hold the raw JPEG data 
            

            try
            {
                int success = TMDLLWrapper.GetTileImageAsRawJPG(zoom, x, y, imgBuffRawJpg, arrSize, out jpgSize);
                if (success == 1)
                {

                    Console.WriteLine("Success LoadTile()!"); 
                }
                else
                {
                    throw new FaultException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occured in LoadTile() method !"+ e);
            }
            return imgBuffRawJpg;

            
        }

        //Deconstructor
        ~TMDataControllerImpl()
        {
            Console.Write("Client is no longer serviced");
        }
    }
}
