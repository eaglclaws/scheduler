﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.Versioning;
using System.Security;

namespace WindowsFormsApp
{
    internal class DocumentExtract
    {
        public static List<string> OpenDocuments()
        {
            List<string> result = new List<string>();
            try
            {
                Word.Application word = (Word.Application)Marshal2.GetActiveObject("Word.Application");
                foreach (Word.Document doc in word.Documents)
                {
                    result.Add(doc.FullName);
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public static class Marshal2
        {
            internal const String OLEAUT32 = "oleaut32.dll";
            internal const String OLE32 = "ole32.dll";

            [System.Security.SecurityCritical]  // auto-generated_required
            public static Object GetActiveObject(String progID)
            {
                Object obj = null;
                Guid clsid;

                // Call CLSIDFromProgIDEx first then fall back on CLSIDFromProgID if
                // CLSIDFromProgIDEx doesn't exist.
                try
                {
                    CLSIDFromProgIDEx(progID, out clsid);
                }
                //            catch
                catch (Exception)
                {
                    CLSIDFromProgID(progID, out clsid);
                }

                GetActiveObject(ref clsid, IntPtr.Zero, out obj);
                return obj;
            }

            //[DllImport(Microsoft.Win32.Win32Native.OLE32, PreserveSig = false)]
            [DllImport(OLE32, PreserveSig = false)]
            [ResourceExposure(ResourceScope.None)]
            [SuppressUnmanagedCodeSecurity]
            [System.Security.SecurityCritical]  // auto-generated
            private static extern void CLSIDFromProgIDEx([MarshalAs(UnmanagedType.LPWStr)] String progId, out Guid clsid);

            //[DllImport(Microsoft.Win32.Win32Native.OLE32, PreserveSig = false)]
            [DllImport(OLE32, PreserveSig = false)]
            [ResourceExposure(ResourceScope.None)]
            [SuppressUnmanagedCodeSecurity]
            [System.Security.SecurityCritical]  // auto-generated
            private static extern void CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] String progId, out Guid clsid);

            //[DllImport(Microsoft.Win32.Win32Native.OLEAUT32, PreserveSig = false)]
            [DllImport(OLEAUT32, PreserveSig = false)]
            [ResourceExposure(ResourceScope.None)]
            [SuppressUnmanagedCodeSecurity]
            [System.Security.SecurityCritical]  // auto-generated
            private static extern void GetActiveObject(ref Guid rclsid, IntPtr reserved, [MarshalAs(UnmanagedType.Interface)] out Object ppunk);

        }
    }
}
