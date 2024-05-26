using System;

public class MoonPhase {

  public static void Main ( string [] args ) {

    MoonPhase moonPhase = new MoonPhase();
    string todaysMoonPhase = moonPhase.calculateMoonPhaseForAGivenDate();
    System.Console.WriteLine( "todays moon phase = " + todaysMoonPhase );

  }

  public string calculateMoonPhaseForAGivenDate() {

    string moonPhase = "";

    DateTime baselineNewMoon = new DateTime( 2022, 2, 1 ); // there was anew moon at 46 mins past midnight (0.0319 days)
    DateTime today = DateTime.Now;

    double differenceInDays = (today - baselineNewMoon).TotalDays - 0.0319; 

    // modulo/ subtract all full moon cycles ( 29.53 days, Wikipedia ). 
    double modulos = differenceInDays % 29.53;  // The remainder is the current mooncycles progress ( phase ).

    // each moonPhase is 29.53 / 8 (for the 8 phases) with the new-moon center = 0
    // currently ~ +/- 19 hour variation either way.

    if (modulos < 1.84 || modulos >= 27.68 )       moonPhase = "newMoon"; 
    else if (modulos >= 1.84 && modulos < 5.53)    moonPhase = "cresent(right)";
    else if (modulos >= 5.53 && modulos < 9.22)    moonPhase = "halfMoon(right)";
    else if (modulos >= 9.22 && modulos < 12.91)   moonPhase = "3of4moon(right)";
    else if (modulos >= 12.91 && modulos < 16.61)  moonPhase = "fullMoon";
    else if (modulos >= 16.61 && modulos < 20.30)  moonPhase = "3of4moon(left)";
    else if (modulos >= 20.30 && modulos < 23.99)  moonPhase = "halfMoon(left)";
    else if (modulos >= 23.99 && modulos < 27.68)  moonPhase = "cresent(left)";

    return moonPhase;

  }


}











