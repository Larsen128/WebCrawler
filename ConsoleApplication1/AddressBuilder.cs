﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class AddressBuilder
    {
        public static string GetNextAlphaNumAddress(string address)
        {
            Uri uri = new Uri(address);


            int[] addressArray = uri.Host.Split('.').Select(x => int.Parse(x)).ToArray();

            if (addressArray.Count() > 100)
            {
                throw new InvalidDataException("l'adresse a un format invalide");
            }

            return IncrementAlphaNumAddress(addressArray);
        }


        public static string GetNextIpv4Address(string address)
        {
            Uri uri = new Uri(address);

            int[] addressArray = uri.Host.Split('.').Select(x => int.Parse(x)).ToArray();

            if (addressArray.Count() != 4)
            {
                throw new InvalidDataException("l'adresse a un format invalide");
            }

            return IncrementAddress(addressArray);
        }


        static string IncrementAlphaNumAddress(string host)
        {
            char lastChar = host.ElementAt(host.Count() - 1);

            if (lastChar != Const.ALPHA_CHARS.ElementAt(Const.ALPHA_CHARS.Count() - 1))
            {
                address[focus]++;
                return GetAddressFromArray(address);
            }
            else
            {
                address[focus] = 0;
                focus--;
                if (host.Count() == 1)
                {

                }
                return IncrementAddress(address, focus);
            }
        }


        static string IncrementAddress(int[] address, int focus = 3)
        {
            if (address[focus] != Const.ADDRESS_MAX)
            {
                address[focus]++;
                return GetAddressFromArray(address);
            }
            else
            {
                address[focus] = 0;
                focus--;
                if (focus < 0)
                {
                    throw new InvalidDataException("Toutes les adresses ont été parcourues");
                }
                return IncrementAddress(address, focus);
            }
        }

        static string GetAddressFromArray(int[] address)
        {
            return "http://" + string.Join(".", address.Select(x => x.ToString()));
        }
    }
}
