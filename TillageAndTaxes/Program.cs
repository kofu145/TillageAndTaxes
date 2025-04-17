using System;
using GramEngine.Core;
using TillageAndTaxes.Scenes;

namespace TillageAndTaxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  dotnet publish -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --self-contained true
        
            WindowSettings windowSettings = new WindowSettings()
            {
                NaiveCollision = false,
                ShowFPS = false,
                ShowColliders = false,
                ColliderCellOffset = 120,
                WindowTitle = "Tillage, Death, and Taxes",
                Width = 1280,
                Height = 720,
            };
            Window window = new Window(new MainTest(), windowSettings);
            try
            {
                window.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                using( StreamWriter writer = new StreamWriter("./error.txt", true ) )
                {
                    writer.WriteLine( "-----------------------------------------------------------------------------" );
                    writer.WriteLine( "Date : " + DateTime.Now.ToString() );
                    writer.WriteLine();

                    while( e != null )
                    {
                        writer.WriteLine( e.GetType().FullName );
                        writer.WriteLine( "Message : " + e.Message );
                        writer.WriteLine( "StackTrace : " + e.StackTrace );

                        e = e.InnerException;
                    }
                }
            }

        }
    }
}