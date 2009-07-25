using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
// Copyright 2007 ICS Electronics div Systems West
namespace Driver
{
    class GPIB_32
    {
        /*******************************************
        %   Integer   Dim L% 
        &   Long      Dim M& 
        @   Decimal   const W@ = 37.5 
        !   Single    Dim Q! 
        #   Double    Dim X# 
        $   String    Dim V$ = "Secret" 
        0x  Hexadecimal
        *******************************************/

        //public Shared ibsta%, iberr%, ibcnt%, ibcntl&
        /// <summary>
        /// Common Static GPIB variables
        /// </summary>
        public static int ibsta;
        public static int iberr;
        public static int ibcnt;
        public static int GPIBInProgress;
        public static long ibcntl;

        /// <summary>
        /// GPIB Commands
        /// </summary>
        //public const int int GTL = 0x1;
        public const int GTL = 0x1;
        public const int SDC = 0x4;
        public const int PPC = 0x5;
        public const int GETT = 0x8;
        public const int TCT = 0x9;
        public const int LLO = 0x11;
        public const int DCL = 0x14;
        public const int PPU = 0x15;
        public const int SPE = 0x18;
        public const int SPD = 0x19;
        public const int UNL = 0x3F;
        public const int UNT = 0x5F;
        public const int PPE = 0x60;

        /// <summary>
        /// Bit specifiers for ibsta status variables and wait mask
        /// </summary>
        public const int EERR = 0x8000;  //Error detected
        public const int TIMO = 0x4000;  //Timeout
        public const int EEND = 0x2000;  //EOI or EOS detected
        public const int SRQI = 0x1000;  //SRQ detected by CIC
        public const int RQS = 0x800;    //Device needs service
        public const int SPOLL = 0x400;  //Board has been serially polled
        public const int eevent = 0x200; //An event has occured
        public const int CMPL = 0x100;   //I/O completed
        public const int LOK = 0x80;     //Local lockout state
        public const int RREM = 0x40;    //Remote state
        public const int CIC = 0x20;     //Controller-in-Charge
        public const int AATN = 0x10;    //Attention asserted
        public const int TACS = 0x8;     //Talker active
        public const int LACS = 0x4;     //Listener active
        public const int DTAS = 0x2;     //Device trigger state
        public const int DCAS = 0x1;     //Device clear state

        /// <summary>
        /// Error codes returned to IBERR variable
        /// </summary>
        public const int EDVR = 0;     //DOS error
        public const int ECIC = 1;     //Board must be CIC for this function
        public const int ENOL = 2;     //No listeners detected
        public const int EADR = 3;     //Board not addressed correctly
        public const int EARG = 4;     //Invalid argument passed to function
        public const int ESAC = 5;     //Function requires GPIB board to be SC
        public const int EABO = 6;     //I/O operation aborted
        public const int ENEB = 7;     //Invalid board specified
        public const int EOIP = 10;    //I/O operation already running
        public const int ECAP = 11;    //Board does not have requested capability
        public const int EFSO = 12;    //Error returned from file system
        public const int EBUS = 14;    //Command error on bus
        public const int ESTB = 15;    //Serial poll response byte lost
        public const int ESRQ = 16;    //SRQ is still asserted
        public const int ETAB = 20;    //No device responding with ETAB

        public const int EINT = 247;   //No interrupt configured on board.
        public const int EWMD = 248;   //Windows is not in enhanced mode
        public const int EVDD = 249;   //CBGPIB.386 is not installed
        public const int EOVR = 250;   //Buffer overflow
        public const int ESML = 251;   //Two library calls running simultaneously
        public const int ECFG = 252;   //Board type doesn//t match GPIB.CFG
        public const int ETMR = 253;   //No Windows timers available
        public const int ESLC = 254;   //No Windows selectors available
        public const int EBRK = 255;   //Ctrl-Break pressed, exiting program

        /// <summary>
        /// EOS mode bits
        /// </summary>
        public const int BIN = 0x1000;
        public const int XEOS = 0x800;
        public const int REOS = 0x400;

        /// <summary>
        /// Timeout code for ibtmo function
        /// </summary>
        public const int TNONE = 0;      //No timeout
        public const int T10us = 1;      //10 usec
        public const int T30us = 2;      //30 usec
        public const int T100us = 3;     //100 usec
        public const int T300us = 4;     //300 usec
        public const int T1ms = 5;       //1 msec
        public const int T3ms = 6;       //3 msec
        public const int T10ms = 7;      //10 msec
        public const int T30ms = 8;      //30 msec
        public const int T100ms = 9;     //100 msec
        public const int T300ms = 10;    //300 msec
        public const int T1s = 11;       //1 sec
        public const int T3s = 12;       //3 sec
        public const int T10s = 13;      //10 sec
        public const int T30s = 14;      //30 sec
        public const int T100s = 15;     //100 sec
        public const int T300s = 16;     //300 sec
        public const int T1000s = 17;    //1000 sec

        /// <summary>
        /// IBLN constants
        /// </summary>
        public const short NO_SAD = 0;
        public const short ALL_SAD = -1;

        /// <summary>
        /// Miscellaneous
        /// </summary>
        public const int S = 0x8;             //parallel poll bit
        public const int LF = 0xA;            //linefeed character
        //public const int short NOADDR  = -1;           //Terminator for address list
        public const int NOADDR = -1;         //Terminator for address list

        public const int NULLend = 0;         //Send() EOTMODE - Do nothing at the end of a transfer.
        public const int NLend = 1;           //Send() EOTMODE - Send NL with EOI after a transfer.
        public const int DABend = 2;          //Send() EOTMODE - Send EOI with the last DAB.
        public const int STOPend = 0x100;     //Receive()( termination
        public const int EventDTAS = 1;       //used by IBEVENT()
        public const int EventDCAS = 2;       //used by IBEVENT()//The following constants are used with ibconfig() to select a

        /// <summary>
        /// The following constants are used with ibconfig() to select a
        /// configurable option.
        /// </summary>
        public const int IbcPAD = 0x1;             //Primary address
        public const int IbcSAD = 0x2;             //Secondary address
        public const int IbcTMO = 0x3;             //Timeout
        public const int IbcEOT = 0x4;             //Send EOI with last byte
        public const int IbcPPC = 0x5;             //Parallel Poll Configure
        public const int IbcREADDR = 0x6;          //Repeat Addressing
        public const int IbcAUTOPOLL = 0x7;        //Disable automatic serial poll
        public const int IbcCICPROT = 0x8;         //Use CIC Protocol
        public const int IbcIRQ = 0x9;             //Interrupt level (or 0 for none)
        public const int IbcSC = 0xA;              //Board is system controller
        public const int IbcSRE = 0xB;             //Assert SRE for dev calls
        public const int IbcEOSrd = 0xC;           //Terminate read on EOS
        public const int IbcEOSwrt = 0xD;          //Send EOI with EOS
        public const int IbcEOScmp = 0xE;          //Use 7 or 8-bit compare with EOS
        public const int IbcEOSchar = 0xF;         //EOS character
        public const int IbcPP2 = 0x10;            //Use PP mode 2
        public const int IbcTIMING = 0x11;         //Normal, High or Very High Speed
        public const int IbcDMA = 0x12;            //DMA channel (or 0 for none)
        public const int IbcReadAdjust = 0x13;     //Swap bytes on read
        public const int IbcWriteAdjust = 0x14;    //Swap bytes on write
        public const int IbcEventQueue = 0x15;     //Use event queue
        public const int IbcSPollBit = 0x16;       //Serial poll bit used
        public const int IbcSendLLO = 0x17;        //Automatically send LLO
        public const int IbcSPollTime = 0x18;      //Serial poll timeout
        public const int IbcPPollTime = 0x19;      //Parallel poll timeout
        public const int IbcEndBitIsNormal = 0x1A; //Set end bit on EOS
        public const int IbcBNA = 0x200;           //A device's access board.
        public const int IbcBaseAddr = 0x201;      //A GPIB board's base I/O address.

        /// <summary>
        /// CBP config items - Don't exist in NI software
        /// </summary>
        public const int IbcBoardType = 0x300;     //Board type
        public const int IbcChipType = 0x301;      //ChipType
        public const int IbcSlotNum = 0x302;       //Slot Number
        public const int IbcPCIIndex = 0x303;      //PCI Index
        public const int IbcBaseAdr2 = 0x304;      //2nd base address for PCI board
        public const int IbcUseFIFOs = 0x305;      //When to use FIFOs

        /// <summary>
        /// These are provided for compatability with NI's library
        /// </summary>
        public const int IbaPAD = 0x1;
        public const int IbaSAD = 0x2;
        public const int IbaTMO = 0x3;
        public const int IbaEOT = 0x4;
        public const int IbaPPC = 0x5;
        public const int IbaREADDR = 0x6;
        public const int IbaAUTOPOLL = 0x7;
        public const int IbaCICPROT = 0x8;
        public const int IbaIRQ = 0x9;
        public const int IbaSC = 0xA;
        public const int IbaSRE = 0xB;
        public const int IbaEOSrd = 0xC;
        public const int IbaEOSwrt = 0xD;
        public const int IbaEOScmp = 0xE;
        public const int IbaEOSchar = 0xF;
        public const int IbaPP2 = 0x10;
        public const int IbaTIMING = 0x11;
        public const int IbaDMA = 0x12;
        public const int IbaReadAdjust = 0x13;
        public const int IbaWriteAdjust = 0x14;
        public const int IbaEventQueue = 0x15;
        public const int IbaSPollBit = 0x16;
        public const int IbaSendLLO = 0x17;
        public const int IbaSPollTime = 0x18;
        public const int IbaPPollTime = 0x19;
        public const int IbaEndBitIsNormal = 0x1A;
        public const int IbaBNA = 0x200;
        public const int IbaBaseAddr = 0x201;

        /// <summary>
        /// CBI config items - Don't exist in NI software
        /// </summary>
        public const int IbaBoardType = 0x300;
        public const int IbaChipType = 0x301;
        public const int IbaSlotNum = 0x302;
        public const int IbaPCIIndex = 0x303;
        public const int IbaBaseAdr2 = 0x304;
        public const int IbaUseFIFOs = 0x305;

        /// <summary>
        /// These bits specify which lines can be monitored by IBLINES
        /// </summary>
        public const int ValidDAV = 0x1;
        public const int ValidNDAC = 0x2;
        public const int ValidNRFD = 0x4;
        public const int ValidIFC = 0x8;
        public const int ValidREN = 0x10;
        public const int ValidSRQ = 0x20;
        public const int ValidATN = 0x40;
        public const int ValidEOI = 0x80;

        /// <summary>
        /// These bits specify the current state of each GPIB line
        /// </summary>
        public const int BusDAV = 0x100;
        public const int BusNDAC = 0x200;
        public const int BusNRFD = 0x400;
        public const int BusIFC = 0x800;
        public const int BusREN = 0x1000;
        public const int BusSRQ = 0x2000;
        public const int BusATN = 0x4000;
        public const int BusEOI = 0x8000;

        /*****************************************
         * 
         *
         * GPIB-32.DLL routines
         * 
         * 
        *****************************************/

        /*****************************************
         * 
         * 488.2 Subroutines
         * 
        *****************************************/
        /// <summary>
        /// Return information about software configuration parameters
        /// </summary>
        /// <param name="ud">Interface or device unit descriptor</param>
        /// <param name="option">Selects the configuration item whose value is being requested</param>
        /// <param name="value"></param>
        /// <output value=Current value of the selected configuration item
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibask(int ud, int option, ref int value);
        /// <summary>
        /// Changes the access interface of a device
        /// </summary>
        /// <param name="ud">A device unit descriptor</param>
        /// <param name="bname">An access interface name such as GPIB0</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibbna(int ud, ref char bname);
        /// <summary>
        /// Become Active Controller
        /// </summary>
        /// <param name="ud">An interface unit descriptor</param>
        /// <param name="v">Determines if control is to be taken</param>
        /// asynchronously or synchronoulsy
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibcac(int ud, int v);
        /// <summary>
        /// Clear a specific device
        /// </summary>
        /// <param name="ud">A device unit descriptor</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibclr(int ud);
        /// <summary>
        /// Send GPIB commands
        /// </summary>
        /// <param name="ud">An interface unit descriptor</param>
        /// <param name="cmdbuf">Buffer of command bytes to send</param>
        /// <param name="count">Number of command bytes to send</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibcmd(int ud, ref byte[] cmdbuf, long count);
        /// <summary>
        /// Send GPIB commands asynchronously
        /// </summary>
        /// <param name="ud">An interface unit descriptor</param>
        /// <param name="combuf">Buffer of command bytes to send</param>
        /// <param name="count">Number of command bytes to send</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibcmda(int ud, ref byte[] combuf, long count);
        /// <summary>
        /// Change the software configuration parameters
        /// </summary>
        /// <param name="ud">Interface or device unit descriptor</param>
        /// <param name="option">A parameter that selects the software configuration item</param>
        /// <param name="value">The value to which the selected configuration item is to be changed</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibconfig(int ud, int option, int value);
        /// <summary>
        /// Open and initialize a device descriptor
        /// </summary>
        /// <param name="BdIndx">Index of the access interface for the device</param>
        /// <param name="pad">The primary GPIB address of the device</param>
        /// <param name="sad">The secondary GPIB address of the device</param>
        /// <param name="tmo">The I/O timeout value</param>
        /// <param name="eot">EOI mode of the device</param>
        /// <param name="eos">EOS character and mode</param>
        /// <returns>The device descriptor or -1</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibdev(int BdIndx, int pad, int sad, int tmo, int eot, int eos);
        /// <summary>
        /// Enable or disable DMA
        /// </summary>
        /// <param name="ud">Interface descriptor</param>
        /// <param name="v">Enable or disabe the use of DMA</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibdma(int ud, int v);
        /// <summary>
        /// Configure the end-of-string (EOS) termination mode or character
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="v"> EOS mode and character information</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibeos(int ud, int v);
        /// <summary>
        /// Enable or diable the automatic assertion of the GPIB EOI at
        /// the end of write I/) operations
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="v">Enables or disables the end of transmission assertion of EOI</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibeot(int ud, int v);
        /// <summary>
        /// Open and initialize an interface or a user-configured device descriptor
        /// </summary>
        /// <param name="udname">A user-configured device or interface name</param>
        /// <returns></returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibfind(ref string udname);
        /// <summary>
        /// Go from Active Controller to Standby
        /// </summary>
        /// <param name="ud">Interface descriptor</param>
        /// <param name="v">Determeinse whether to perform acceptor handshaking</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibgts(int ud, int v);
        /// <summary>
        /// Set or clear the interface individual sttaus bit for parallel polls
        /// </summary>
        /// <param name="ud">Interface descriptor</param>
        /// <param name="v">Indicates whether to set or clear the 1st bit</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibist(int ud, int v);
        /// <summary>
        /// Return the status of the eight BPIB control lines
        /// </summary>
        /// <param name="ud">Interface descriptor</param>
        /// <param name="clines">GPIB control line state information</param>
        /// <returns></returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibline(int ud, ref short clines);
        /// <summary>
        /// Check for the presence of a device on the bus
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="pad">The primary GPIB address of the device</param>
        /// <param name="sad">The secondary GPIB address of the device</param>
        /// <param name="listen">Indicates if a device is present or not</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibln(int ud, int pad, int sad, ref short listen);
        /// <summary>
        /// Go to Local
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibloc(int ud);
        //[DllImport("GPIB-32.dll")]
        //public static extern int ibnotify(int ud, int mask, 
        /// <summary>
        /// Place the device or interface online or offline
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="v">Indicates whether the interface or device is to be
        /// take online or offline</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibonl(int ud, int v);
        /// <summary>
        /// Change the primary address
        /// </summary>
        /// <param name="ud">interface or device descriptor</param>
        /// <param name="v">GPIB primary address</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibpad(int ud, int v);
        /// <summary>
        /// Pass control to another GPIB device with Controller capability
        /// </summary>
        /// <param name="ud">Device descriptor</param>
        /// <returns>Teh value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibpct(int ud);
        /// <summary>
        /// parallel poll configure
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="v"></param>
        /// <returns>The bvalue of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibppc(int ud, int v);
        /// <summary>
        /// Read data from a device into a user buffer
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="rdbuf">Buffer into which data is read</param>
        /// <param name="count">Number of bytes to be read from the GPIB</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibrd(int ud, byte[] rdbuf, long count);
        /// <summary>
        /// Read data asynchronously from a device into a user buffer
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="rdbuf">Buffer into which data is read</param>
        /// <param name="count">Number of bytes to be read from the GPIB</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibrda(int ud, ref int rdbuf, long count);
        /// <summary>
        /// 
        /// read data from a device into a file
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="flname">Name of file into which data is read</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibrdf(int ud, ref string flname);
        /// <summary>
        /// Conduct a parallel poss
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="ppr">Paralled poll response byte</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibrpp(int ud, ref byte ppr);
        /// <summary>
        /// Request or release system control
        /// </summary>
        /// <param name="ud">Interface descriptor</param>
        /// <param name="v">Determines if system control is to be requested or released</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibrsc(int ud, int v);
        /// <summary>
        /// Conduct a serial poll
        /// </summary>
        /// <param name="ud">Device descriptor</param>
        /// <param name="spr">Serial poll response byte</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibrsp(int ud, ref byte spr);
        /// <summary>
        /// Request service and change the serial poll status byte
        /// </summary>
        /// <param name="ud">Interface descriptor</param>
        /// <param name="v">Serial poll status byte</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibrsv(int ud, int v);
        /// <summary>
        /// Change or disable the secondary address
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="v">GPIB secondary address</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibsad(int ud, int v);
        /// <summary>
        /// Assert interface clear
        /// </summary>
        /// <param name="ud">Interface descriptor</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibsic(int ud);
        /// <summary>
        /// Set or clear the Remote Enable (REN) line
        /// </summary>
        /// <param name="ud">Interface descriptor</param>
        /// <param name="v">Indicates whether to set or clear the REN line</param>
        /// <returns></returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibsre(int ud, int v);
        /// <summary>
        /// Abort asynchronous I/O operation
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibstop(int ud);
        /// <summary>
        /// Change or disable the I/O timeout period
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="v">Timeout duration code</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibtmo(int ud, int v);
        /// <summary>
        /// Trigger selected device
        /// </summary>
        /// <param name="ud">Device descriptor</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibtrg(int ud);
        /// <summary>
        /// Wait for GPIB events
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="maks">Bit mask of GPIB events to wait for</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibwait(int ud, int maks);
        /// <summary>
        /// Write data to a device from a user buffer
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="wrtbuf">Buffer containing the bytes to write</param>
        /// <param name="count">Number of bytes to be written</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibwrt(int ud, byte[] wrtbuf, long count);
        /// <summary>
        /// Write data asynchronously to a device from a user buffer
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="wrtbuf">Buffer containing the bytes to write</param>
        /// <param name="count">Number of bytes to be written</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibwrta(int ud, byte[] wrtbuf, long count);
        /// <summary>
        /// Write data to a device from a file
        /// </summary>
        /// <param name="ud">Interface or device descriptor</param>
        /// <param name="flname">Name of file containing the data to be written</param>
        /// <returns>The value of ibsta</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ibwrtf(int ud, ref string flname);

        /*****************************************
         * 
         * 488.2 Multi-Device Calls
         * 
        *****************************************/

        /// <summary>
        /// Serial poll all devices
        /// </summary>
        /// <param name="boardID">Theinterface number</param>
        /// <param name="addrlist">A list of device addresses that is terminated by NOADDR</param>
        /// <param name="resultlist">A list of serial poll response bytes corresponding to
        /// device addresses in addrlist</param>
        [DllImport("GPIB-32.dll")]
        public static extern void AllSpoll(int boardID, short[] addrlist, short[] resultlist);
        //public static extern void AllSpoll(int boardID, short[] addrlist, ref short[] resultlist);
        /// <summary>
        /// Clear a single device
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">Address of the device you want to clear</param>
        [DllImport("GPIB-32.dll")]
        public static extern void DevClear(int boardID, short address);
        /// <summary>
        /// Clear multiple devices
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device address terminated by NOADDR
        /// that you want to clear</param>
        [DllImport("GPIB-32.dll")]
        public static extern void DevClearList(int boardID, short[] addrlist);
        /// <summary>
        /// Enable operations from the front panel of devices (leave remote programming mode)
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device addresses that is terminated by NOADDR</param>
        [DllImport("GPIB-32.dll")]
        public static extern void EnableLocal(int boardID, short[] addrlist);
        /// <summary>
        /// Enable remote GPIB programming for device
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device addresses that is terminated by NOADDR</param>
        [DllImport("GPIB-32.dll")]
        public static extern void EnableRemote(int boardID, short[] addrlist);
        /// <summary>
        /// Find listening devices on the GPIB
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="padlist">Alist of primary address that is terminated by NOADDR</param>
        /// <param name="resultlist">Addresses of all listening devices found by FindLstn
        /// are placed in this array</param>
        /// <param name="limit">Total number of entries that can be placed in resultlist</param>
        [DllImport("GPIB-32.dll")]
        public static extern void FindLstn(int boardID, short[] padlist, short[] resultlist, int limit);
        /// <summary>
        /// Determine which device is requesting service
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">List of device addresses that is terminated by NOADDR</param>
        /// <param name="result">Serial poll response of the device that is requesting service</param>
        [DllImport("GPIB-32.dll")]
        public static extern void FindRQS(int boardID, short[] addrlist, ref short result);
        /// <summary>
        /// Pass control to another device with Controller capability
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">Address of the device to which you want to pass control</param>
        [DllImport("GPIB-32.dll")]
        public static extern void PassControl(int boardID, short address);
        /// <summary>
        /// Perform a parallel poll on the GPIB
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="result">The parallel poll result</param>
        [DllImport("GPIB-32.dll")]
        public static extern void PPoll(int boardID, ref short result);
        /// <summary>
        /// Configure a device to respond to parallel polls
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">Address of the device to be configured</param>
        /// <param name="dataline">Data line(a value in the range of 1 to 8) on
        /// which the device responds to parallel polls</param>
        /// <param name="lineSense">Sense(either 0 or 1) of the parallel poll response</param>
        [DllImport("GPIB-32.dll")]
        public static extern void PPollConfig(int boardID, short address, int dataline, int lineSense);
        /// <summary>
        /// Unconfigure devices for parallel polls
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device addresses that is terminated by NOADDR</param>
        [DllImport("GPIB-32.dll")]
        public static extern void PPollUnconfig(int boardID, short[] addrlist);
        /// <summary>
        /// Read data bytes from a device that is already addressed to talk
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="buffer">Stores the received data bytes</param>
        /// <param name="count">Number of bytes read</param>
        /// <param name="termination">Description of the data termination mode
        /// (STOPend or an 8-bit EOS character</param>
        
        // THIS IS NOT PROPERLY WRAPED 
        [DllImport("GPIB-32.dll")]
        public static extern void RcvRespMsg(int boardID, StringBuilder buffer, long count, int termination);
        /// <summary>
        /// Serial poll a single device
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">A device address</param>
        /// <param name="result">Serial poll response byte</param>
        [DllImport("GPIB-32.dll")]
        public static extern void ReadStatusByte(int boardID, int address, ref short result);
        /// <summary>
        /// Read data bytes from a device
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">Address of a device to receive data</param>
        /// <param name="buffer">Stores the received data bytes</param>
        /// <param name="count">Number of bytes to read</param>
        /// <param name="termination">Description of the data termination mode
        /// (STOPend or an EOS character)</param>
        // With out [In, Out] In in is assumed
        [DllImport("GPIB-32.dll")]
        public static extern void Receive(int boardID, int address, [In, Out] byte[] buffer, int count, int termination);
        //public static extern void Receive(int boardID, short address, byte[] buffer, long count, int termination);
        /// <summary>
        /// Address a device to be a Talker and the interface to be a Listener
        /// in preparation for RcvRespMsg
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">Address of a device to be talk adddressed</param>
        
        public static String Receive_String(int boardID, int address, int count, int termination)
        {
            byte [] byte_buf = new byte[count];
            char[] char_arr = new char[count];

            // Get the data
            Receive(boardID, address, byte_buf, count, termination);
            Check_Err("Receive Error: ");

            // convert it to a character array
            int i = 0;
            for (i = 0; i < count; i++)
            {
                char_arr[i] = Convert.ToChar(byte_buf[i]);

                // Do not copy the CR, LF
                if ((char_arr[i] == '\r') || (char_arr[i] == '\n'))
                {
                    char_arr[i] = '\0';
                    break;
                }
            }

            return (new String(char_arr,0,i));
        }

        /// <summary>
        /// Read data bytes from a device
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">Address of a device to receive data</param>
        /// <param name="count">Number of shorts to read</param>
        /// <param name="termination">Description of the data termination mode</param>
        /// <returns>An Array of shorts read</returns>
        /// (STOPend or an EOS character)</param>
        public static ushort[] Receive_Ushort(int boardID, int address, int count, int termination)
        {          
            byte[] byte_buf = new byte[count*2];
            ushort[] ushort_arr = new ushort[count];

            Receive(boardID, address, byte_buf, count*2, termination);
            Check_Err("Receive Ushort Error: ");

            for (int i = 0; i < count; i++)
            {            
                // Origionally used BitConverter.ToUInt16, but it does not work properly
                // Doing the conversion manually
                ushort_arr[i] = (ushort) (byte_buf[i * 2]<<8);
                ushort_arr[i] += (ushort) byte_buf[i * 2+1]; 
            }
            copy_globals();


            return (ushort_arr);
        }


        [DllImport("GPIB-32.dll")]
        public static extern void ReceiveSetup(int boardID, short address);
        /// <summary>
        /// Reset and initialize IEEE 488.2-compliant devices
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device address that is terminated by NOADDR</param>
        [DllImport("GPIB-32.dll")]
        public static extern void ResetSys(int boardID, short[] addrlist);
        /// <summary>
        /// Send data bytes to a device
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">Address of a device to which data is sent</param>
        /// <param name="buffer">The data bytes to be sent</param>
        /// <param name="count">Number of bytes to be sent</param>
        /// <param name="eotmode">The data termination mode:
        /// DABend, NULLend, or NLend</param>
        [DllImport("GPIB-32.dll")]
        public static extern void Send(int boardID, int address, string buffer, int count, int eotmode);
        //public static extern void Send(int boardID, short address, byte[] buffer, long count, int eotmode);
        /// <summary>
        /// Send data bytes to devices that are already addressed to listen
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="buffer">The data bytes to be sent</param>
        /// <param name="count">Number of bytes to be sent</param>
        /// <param name="eotmode">The data termination mode:
        /// DABend, NULLend, or NLend</param>
        [DllImport("GPIB-32.dll")]
        public static extern void SendDataBytes(int boardID, string buffer, long count, int eotmode);
        /// <summary>
        /// Reset the GPIB by sending the interface clear
        /// </summary>
        /// <param name="boardID">The interface number</param>
        [DllImport("GPIB-32.dll")]
        public static extern void SendIFC(int boardID);
        /// <summary>
        /// Send data bytes to multiple GPIB devices
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device addresses to send data</param>
        /// <param name="buffer">The data bytes to be sent</param>
        /// <param name="count">Number of bytes transmitted</param>
        /// <param name="eotmode">The data termination mode:
        /// DABend, NULLend, of NLend</param>
        [DllImport("GPIB-32.dll")]
        public static extern void SendList(int boardID, short[] addrlist, string buffer, long count, int eotmode);
        /// <summary>
        /// Send the Local Lockout (LLO) message to all devices
        /// </summary>
        /// <param name="boardID">The interface number</param>
        [DllImport("GPIB-32.dll")]
        public static extern void SendLLO(int boardID);
        /// <summary>
        /// Set up devices to receive data in preparation for SendDataBytes
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device addresses that is terminated by NOADDR</param>
        [DllImport("GPIB-32.dll")]
        public static extern void SendSetup(int boardID, short[] addrlist);
        /// <summary>
        /// Place devices in Remot With Lockout State
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device addresses that is terminated by NOADDR</param>
        [DllImport("GPIB-32.dll")]
        public static extern void SetRWLS(int boardID, short[] addrlist);
        /// <summary>
        /// Determine the current state of the GPIB Request (SRQ) line
        /// </summary>
        /// <param name="boardID">Ther interface number</param>
        /// <param name="result">State of the ARQ line: non-zero if the line
        /// is asserted, zero if the line is not asserted</param>
        [DllImport("GPIB-32.dll")]
        public static extern void TestSRQ(int boardID, ref short result);
        /// <summary>
        /// Cause IEEE-488.2-compliant devices to connduct self tests
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device addresses terminated by NOADDR</param>
        /// <param name="resultlist">A list of rest results; each entry
        /// corresponds to an address in addrlist</param>
        [DllImport("GPIB-32.dll")]
        public static extern void TestSys(int boardID, short[] addrlist, short[] resultlist);
        /// <summary>
        /// Trigger a device
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="address">Address of a device to be triggered</param>
        [DllImport("GPIB-32.dll")]
        public static extern void Trigger(int boardID, short address);
        /// <summary>
        /// Trigger multiple devices
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="addrlist">A list of device addresses terminated by NOADDR</param>
        [DllImport("GPIB-32.dll")]
        public static extern void TriggerList(int boardID, short[] addrlist);
        /// <summary>
        /// Wait until a device asserts the GPIB Service Request (SRQ) line
        /// </summary>
        /// <param name="boardID">The interface number</param>
        /// <param name="result">State of the SRQ line: non-zero if line
        /// is asserted, zero if line is not asserted</param>
        [DllImport("GPIB-32.dll")]
        public static extern void WaitSRQ(int boardID, ref short result);
        /// <summary>
        /// Returns the value of the thread-specific ibcnt
        /// </summary>
        /// <returns>Value of ibcnt for the calling thread</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ThreadIbcnt();
        /// <summary>
        /// Returns the value of the thread-specific ibcntl
        /// </summary>
        /// <returns>Value of ibcntl for the calling thread</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ThreadIbcntl();
        /// <summary>
        /// Returns the value of the thread-specific iberr
        /// </summary>
        /// <returns>Value of iberr for the calling thread</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ThreadIberr();
        /// <summary>
        /// Returns the value of the thread-specific ibsta
        /// </summary>
        /// <returns>Value of ibsta for the calling thread</returns>
        [DllImport("GPIB-32.dll")]
        public static extern int ThreadIbsta();

        public static void copy_globals()
        {
            ibcntl = ThreadIbcntl();
            iberr = ThreadIberr();
            ibsta = ThreadIbsta();
            ibcnt = ThreadIbcnt();
        }
        /************************
         * 
         * 488.1 Functions
         * 
        ************************/

        /************************************************/
        public static int ilask(int dev, int opt, int rval)
        {
            int value;
            value = ibask(dev, opt, ref rval);
            copy_globals();
            return value;
        }

        public static int ilbna(int dev, char devname)
        {
            int value;
            value = ibbna(dev, ref devname);
            copy_globals();
            return value;
        }

        public static int ilcac(int dev, int v)
        {
            int value;
            value = ibcac(dev, v);
            copy_globals();
            return value;
        }

        public static int ilclr(int dev)
        {
            int value;
            value = ibclr(dev);
            copy_globals();
            return value;
        }

        public static int ilcmd(int dev, ref byte[] buf, long cnt)
        {
            int value;
            value = ibcmd(dev, ref buf, cnt);
            copy_globals();
            return value;
        }

        public static int ilcmda(int dev, ref byte[] buf, long cnt)
        {
            int value;
            value = ibcmd(dev, ref buf, cnt);
            copy_globals();
            return value;
        }

        public static int ilconfig(int bdid, int opt, int v)
        {
            int value;
            value = ibconfig(bdid, opt, v);
            copy_globals();
            return value;
        }

        public static int ildev(int bdid, int pad, int sad, int tmo, int eot, int eos)
        {
            int value;
            value = ibdev(bdid, pad, sad, tmo, eot, eos);
            copy_globals();
            return value;
        }

        public static int ildma(int dev, int v)
        {
            int value;
            value = ibdma(dev, v);
            copy_globals();
            return value;
        }

        public static int ileos(int dev, int v)
        {
            int value;
            value = ibeos(dev, v);
            copy_globals();
            return value;
        }

        public static int ileot(int dev, int v)
        {
            int value;
            value = ibeot(dev, v);
            copy_globals();
            return value;
        }

        /**public static int ilevent(int dev, int eevent)
        {
            int value;
            value = ibevent(dev, eevent);
            copy_globals();
            return value;
        }**/

        public static int ilfind(string devname)
        {
            int value;
            value = ibfind(ref devname);
            copy_globals();
            return value;
        }

        public static int ilgts(int dev, int v)
        {
            int value;
            value = ibgts(dev, v);
            copy_globals();
            return value;
        }

        /**public static int ilinit(int dev)
        {
            int value;
            value = ibinit(dev);
            copy_globals();
            return value;
        }**/

        public static int ilist(int dev, int v)
        {
            int value;
            value = ibist(dev, v);
            copy_globals();
            return value;
        }

        /**public static short illines(int dev, short lines)
        {
            int value;
            value = iblines(dev, lines);
            copy_globals();
            return value;
        }**/

        public static int illn(int dev, int pad, int sad, ref short listener)
        {
            int value;
            value = ibln(dev, pad, sad, ref listener);
            copy_globals();
            return value;
        }

        public static int illoc(int dev)
        {
            int value;
            value = ibloc(dev);
            copy_globals();
            return value;
        }

        public static int ilonl(int dev, int v)
        {
            int value;
            value = ibonl(dev, v);
            copy_globals();
            return value;
        }

        public static int ilpad(int dev, int v)
        {
            int value;
            value = ibpad(dev, v);
            copy_globals();
            return value;
        }

        public static int ilpct(int dev)
        {
            int value;
            value = ibpct(dev);
            copy_globals();
            return value;
        }

        public static int ilppc(int dev, int v)
        {
            int value;
            value = ibppc(dev, v);
            copy_globals();
            return value;
        }

        public static int ilrd(int dev, byte[] buf, long cnt)
        {
            int value;
            value = ibrd(dev, buf, cnt);
            copy_globals();
            return value;
        }

        public static int ilrda(int dev, byte[] buf, int cnt)
        {
            int value;
            value = ibrd(dev, buf, cnt);
            copy_globals();
            return value;
        }

        public static int ilrdf(int dev, ref string filename)
        {
            int value;
            value = ibrdf(dev, ref filename);
            copy_globals();
            return value;
        }

        /**public static int ilrdi(int dev, int ibuf, int cnt)
    {
           int value;
           value = ibrdi(dev, ibuf, cnt);
           copy_globals();
            return value;
        }**/

        /**public static int ilrdia(int dev, int ibuf, int cnt)
    {
            int value;
            value = ibrdi(dev, ibuf, cnt);
            copy_globals();
            return ValueType;
        }**/

        public static int ilrpp(int dev, ref Byte ppr)
        {
            int value;
            value = ibrpp(dev, ref ppr);
            copy_globals();
            return value;
        }

        public static int ilrsc(int dev, int v)
        {
            int value;
            value = ibrsc(dev, v);
            copy_globals();
            return value;
        }

        public static int ilrsp(int dev, ref byte rsp)
        {
            int value;
            value = ibrsp(dev, ref rsp);
            copy_globals();
            return value;
        }

        public static int ilrsv(int dev, int v)
        {
            int value;
            value = ibrsv(dev, v);
            copy_globals();
            return value;
        }

        public static int ilsad(int dev, int v)
        {
            int value;
            value = ibsad(dev, v);
            copy_globals();
            return value;
        }

        public static int ilsic(int dev)
        {
            int value;
            value = ibsic(dev);
            copy_globals();
            return value;
        }

        public static int ilsre(int dev, int v)
        {
            int value;
            value = ibsre(dev, v);
            copy_globals();
            return value;
        }

        public static int ilstop(int dev)
        {
            int value;
            value = ibstop(dev);
            copy_globals();
            return value;
        }

        public static int ILTMO(int dev, int v)
        {
            int value;
            value = ibtmo(dev, v);
            copy_globals();
            return value;
        }

        public static int iltrg(int dev)
        {
            int value;
            value = ibtrg(dev);
            copy_globals();
            return value;
        }

        public static int ilwait(int dev, int mask)
        {
            int value;
            value = ibwait(dev, mask);
            copy_globals();
            return value;
        }

        public static int ilwrt(int dev, byte[] buf, long cnt)
        {
            int value;
            value = ibwrt(dev, buf, cnt);
            copy_globals();
            return value;
        }

        public static int ilwrta(int dev, byte[] buf, long cnt)
        {
            int value;
            value = ibwrt(dev, buf, cnt);
            copy_globals();
            return value;
        }

        public static int ilwrtf(int dev, ref string filename)
        {
            int value;
            value = ibwrtf(dev, ref filename);
            copy_globals();
            return value;
        }

        public static void Check_Err(String str)
        {
            copy_globals();

            // Check for an error
            if (((GPIB_32.ibsta & GPIB_32.EERR) == GPIB_32.EERR) ||
                ((GPIB_32.ibsta & GPIB_32.TIMO) == GPIB_32.TIMO))
            {
                // Throw a exception
                Exception ex = new Exception(ICSconstants.GPIBerr(str + "\n"));

                throw (ex);
            }
        }

        /**public static int ilwrti(int dev, int ibuf, int cnt)
        {
            int value;
            value = ibwrti(dev, ibuf, cnt);
            copy_globals();
            return value;
        }**/

        /**public static int ilwrtia(int dev, int ibuf, int cnt)
        {
            int value;
            value = ibwrti(dev, ibuf, cnt);
            copy_globals();
            return value;
        }**/
        /*************************************/

        /**public static int ibask(int ud, int option, ref int value)
        {
            int error;
            error = -1;
            return error;
        }
        /**********************************
         * *********************************/
    }
}
