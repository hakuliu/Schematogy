using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Schematogy
{
    class GridLoader
    {
        public class GridState
        {
            public enum CellType
            {
                Empty,              //0
                WireHorizontal,     //1
                WireVertical,       //2
                WireTopLeft,        //.
                WireTopRight,       //.
                WireBottomLeft,     //.
                WireBottomRight,
                ResistorEmpty,
            }


            public CellType[,] cells;

            public GridState(int sizeX, int sizeY)
            {
                cells = new CellType[sizeX, sizeY];
            }
        }

        public static GridState LoadFromFile(String file)
        {
            String directoryToLookFor = "Content/Maps/";
            try
            {
                using (StreamReader sr = new StreamReader(directoryToLookFor + file))
                {
                    String line;
                    int lineNum = -1;
                    int sizeX = 0;
                    int sizeY = 0;
                    GridState gridState = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (lineNum == -1)
                        {
                            String[] sizes = line.Split(new char[] { ',' });
                            
                            if (sizes.Length != 2)
                            {
                                throw new Exception("Size line was not 2.");
                            }
                            if (!int.TryParse(sizes[0], out sizeX))
                            {
                                throw new Exception("X was not an integer");
                            }
                            if (!int.TryParse(sizes[1], out sizeY))
                            {
                                throw new Exception("Y was not an integer");
                            }
                            gridState = new GridState(sizeX, sizeY);
                        }
                        else
                        {
                            String[] row = line.Split(new char[] { ',' });

                            if (sizeX != row.Length)
                            {
                                throw new Exception("size of data does not match specified size on file");
                            }
                            if (gridState != null)
                            {
                                for (int i = 0; i < sizeX; i++)
                                {
                                    //int val = -1;
                                    //if (!Int32.TryParse(row[i], out val))
                                    //{
                                        gridState.cells[i, lineNum] = (GridState.CellType)Int32.Parse(row[i]);
                                    //}
                                    //else
                                    //{
                                    //    throw new Exception("could not parse int. " + row[i]);
                                    //}
                                    
                                }
                            }
                        }
                        Console.WriteLine(line);
                        lineNum++;
                    }
                    return gridState;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("uh oh...I can't read that map file..." + e.Message);
                return null;
            }
        }
    }
}
