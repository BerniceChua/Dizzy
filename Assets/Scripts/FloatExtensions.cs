using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions {

	public static string AddOneLeadingZero(this float floatNumber) {
        /// Check if it is a 1-digit number.
        /// (If it is a 1-digit number, add a leading zero.)
        if (floatNumber < 10) {
            return "0" + floatNumber.ToString("f2");
        }

        return floatNumber.ToString("f2");
    }
}