using System;
using System.Collections.Generic;
using System.Text;

// Copyright 2007 ICS Electronics div Systems West
namespace Lab.Drivers.HP8594E
{
    class ICSconstants
    {
        public short BD;            //board number
	    public short dev;           //units GPIB address
	    public short addr;          //unit's GPIB adddress, combined value
	    public short MODEL;         //unit ID
        //public short bddev As Short //current device handle
	    public short priaddr;       //unit's primary address
	    public short secaddr;       //unit's secondary address
	    public short NADDR;
	    public string NL;           //new line
	    public string Msg;          //error message
	    public string RetMsg;    
	    public string Notice;       //configuration message
	    public string CmdStr;
	    public string UnTalk;
	    public string UnListen;
	    public string EventStatus;
	    public string Rdg;
	    public string LSTNDEV;
	    public string TALKDEV;
        public static string GPIBerr(string Msg)
        {
            //string tempString;
            string errMessage;
            string eMsg;
            /***********************************************************************
             *                     Subroutine GPIBERR
             * This subroutine will notify you that a NI-488.2 subroutine failed by
             * printing an error message.  The status variable IBSTA% will also be
             * printed in hexadecimal along with the mnemonic meaning of the bit positions.
             * The status variable IBERR% will be printed in decimal along with the
             * mnemonic meaning of the decimal value.  The status variable IBCNTL& will
             * be printed in decimal.
             * 
             * The NI-488 function IBONL is called to disable the hardware and software.
            ************************************************************************/
            errMessage = String.Copy(Msg);
            errMessage = String.Concat(errMessage, ", GPIB-32.ibstat = &H");
            errMessage = String.Concat(errMessage, GPIB_32.ibsta.ToString("X"));
            errMessage = String.Concat(errMessage, " <");
            if ((GPIB_32.ibsta & GPIB_32.EERR) == GPIB_32.EERR)
                eMsg = "ERR: GPIB error";
            else if ((GPIB_32.ibsta & GPIB_32.TIMO) == GPIB_32.TIMO)
                eMsg = "TIMO: Timeout";
            else if ((GPIB_32.ibsta &  GPIB_32.EEND) == GPIB_32.EEND)
                eMsg = "END: END or EOS detected";
            else if ((GPIB_32.ibsta &  GPIB_32.SRQI) == GPIB_32.SRQI)
                eMsg = "SRQI: SRQ interupt received ";
            else if ((GPIB_32.ibsta & GPIB_32.RQS) == GPIB_32.RQS)
                eMsg = "RQS: Device requesting service ";
            else if ((GPIB_32.ibsta & GPIB_32.SPOLL) == GPIB_32.SPOLL)
                eMsg = "SPOLL: ";
            else if ((GPIB_32.ibsta & GPIB_32.CMPL) == GPIB_32.CMPL)
                eMsg = "CMPL: I/O complete";
            else if ((GPIB_32.ibsta &  GPIB_32.LOK) == GPIB_32.LOK)
                eMsg = "LOK:  Lockout state";
            else if ((GPIB_32.ibsta & GPIB_32.LOK) == GPIB_32.RREM)
                eMsg = "REM: Remote State";
            else if ((GPIB_32.ibsta & GPIB_32.CIC) == GPIB_32.CIC)
                eMsg = "CIC: Controller-in-charge";
            else if ((GPIB_32.ibsta & GPIB_32.AATN) == GPIB_32.AATN)
                eMsg = "ATN: Attention asserted";
            else if ((GPIB_32.ibsta & GPIB_32.TACS) == GPIB_32.TACS)
                eMsg = "TACS: Talker";
            else if ((GPIB_32.ibsta & GPIB_32.LACS) == GPIB_32.LACS)
                eMsg = "LCAS: Listener";
            else if ((GPIB_32.ibsta & GPIB_32.DTAS) == GPIB_32.DTAS)
                eMsg = "DTAS: Device Trigger State";
            else if ((GPIB_32.ibsta & GPIB_32.DCAS) == GPIB_32.DCAS)
                eMsg = "DCAS: Device Clear State ";
            else if (GPIB_32.ibsta == 0)
                eMsg = "No State";
            else
                eMsg = "";

            errMessage = String.Concat(errMessage, eMsg);
            errMessage = String.Concat(errMessage, " >, GPIB-32.iberr = ");
            errMessage = String.Concat(errMessage, GPIB_32.iberr.ToString());
            if (GPIB_32.iberr == GPIB_32.EDVR)
                eMsg = " EDVR <Op System Error>";
            else if (GPIB_32.iberr == GPIB_32.ECIC)
                eMsg = " ECIC <Not CIC>";
            else if (GPIB_32.iberr == GPIB_32.ENOL)
                eMsg = " ENOL <No Listener>";
            else if (GPIB_32.iberr == GPIB_32.EADR)
                eMsg = " EADR <Address error>";
            else if (GPIB_32.iberr == GPIB_32.EARG)
                eMsg = " EARG <Invalid argument>";
            else if (GPIB_32.iberr == GPIB_32.ESAC)
                eMsg = " ESAC <Not Sys Ctrlr>";
            else if (GPIB_32.iberr == GPIB_32.EABO)
                eMsg = " EABO <Operation aborted>";
            else if (GPIB_32.iberr == GPIB_32.ENEB)
                eMsg = " ENEB <No GPIB board>";
            else if (GPIB_32.iberr == GPIB_32.EOIP)
                eMsg = " EOIP <Async I/O in prg>";
            else if (GPIB_32.iberr == GPIB_32.ECAP)
                eMsg = " ECAP <No capability>";
            else if (GPIB_32.iberr == GPIB_32.EFSO)
                eMsg = " EFSO <File sys. error>";
            else if (GPIB_32.iberr == GPIB_32.EBUS)
                eMsg = " EBUS <Command error>";
            else if (GPIB_32.iberr == GPIB_32.ESTB)
                eMsg = " ESTB <Status byte lost>";
            else if (GPIB_32.iberr == GPIB_32.ESRQ)
                eMsg = " ESRQ <SRQ stuck on>";
            else if (GPIB_32.iberr == GPIB_32.ETAB)
                eMsg = " ETAB <Table Overflow>";
            errMessage = String.Concat(errMessage, eMsg);
            errMessage = String.Concat(errMessage, ", GPIB-32.ibcnt = ");
            errMessage = String.Concat(errMessage, GPIB_32.ibcntl.ToString());
            return errMessage;
        }
    }
}