
/*
    * File:
        main_I2C_master.c
    * Author:
        mar
    *
    * Created on 8 mars 2017, 10:
        58
    */


# include <stdio.h>
# include <stdlib.h>
# include <xc.h>
# include <p18cxxx.h>
# include <pic18f8722.h>
# include <stdlib.h>
# include <plib\delays.h>
# include <plib\adc.h>
// ----------------------
// Configuration Hardware
// ----------------------

# pragma config	OSC = HSPLL
# pragma config	FCMEN = OFF
# pragma config	IESO = OFF
# pragma config	PWRT = OFF
# pragma config	BOREN = OFF
# pragma config	MCLRE = ON
# pragma config  WDT = OFF
# pragma config	LVP = OFF
# pragma config	XINST = OFF

void write_Arduino(unsigned char address_puce, unsigned char address_reg, unsigned char data)
void i2c_init()
void i2c_waitForIdle()
void i2c_start()
void i2c_repStart()
void i2c_stop()
int i2c_read(unsigned char ack)
unsigned char i2c_write(unsigned char i2cWriteData)

unsigned char address = 0x12


void main(void)
{
    i2c_init()

    while(1)
    {


    }
}

void write_Arduino(unsigned char address_puce, unsigned char address_reg, unsigned char data)
    {

    }

void i2c_init()
{
    TRISCbits.RC3 = 1
    // set SCL pin as input
    TRISCbits.RC4 = 1
    // set SDA pin as input

    SSP1CON1 = 0x38
    // set I2C master mode
    SSP1CON2 = 0x00

    // 400kHz bus with 10MHz xtal - use 0x0C with 20MHz xtal
    SSP1ADD = 10
    // 100k at 4Mhz clock

    SSP1STATbits.CKE = 0
    // use I2C levels      worked also with '0'
    SSP1STATbits.SMP = 0
    // disable slew rate control  worked also with '0'

    PIR1bits.PSPIF = 0
    // clear SSPIF interrupt flag
    PIR2bits.BCL1IF = 0
    // clear bus collision flag
}

/******************************************************************************************/

void i2c_waitForIdle()
{
    while ((SSP1CON2 & 0x1F) | SSP1STATbits.RW) {}
    // wait for idle and not writing
}

/******************************************************************************************/

void i2c_start()
{
    i2c_waitForIdle()
    SSP1CON2bits.SEN = 1
}

/******************************************************************************************/

void i2c_repStart()
{
    i2c_waitForIdle()
    SSP1CON2bits.RSEN = 1
}

/******************************************************************************************/

void i2c_stop()
{
    i2c_waitForIdle()
    SSP1CON2bits.PEN = 1
}

/******************************************************************************************/

int i2c_read(unsigned char ack)
{
    unsigned char i2cReadData

    i2c_waitForIdle()

    SSP1CON2bits.RCEN = 1

    i2c_waitForIdle()

    i2cReadData = SSP1BUF

    i2c_waitForIdle()

    if (ack)
    {
        SSP1CON2bits.ACKDT = 0
    }
    else
    {
        SSP1CON2bits.ACKDT = 1
    }
    SSP1CON2bits.ACKEN = 1
    // send acknowledge sequence

    return(i2cReadData)
}

/******************************************************************************************/

unsigned char i2c_write(unsigned char i2cWriteData)
{
    i2c_waitForIdle()
    SSP1BUF = i2cWriteData

    return (! SSP1CON2bits.ACKSTAT)
    // function returns '1' if transmission is acknowledged
}

/******************************************************************************************/
