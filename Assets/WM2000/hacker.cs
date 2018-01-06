using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour {

    // Use this for initialization
    int level;
    string password = "none";
    string[,] passwordLevel = new string[4, 10];
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string nuclearBase =  "You now have breached Military Airbase\n"+
                           "     |     | | \n"
                         + "    / \\    | | \n"
                         + "   |--o|===|-| \n"
                         + "   |---|   |P| \n"
                         + "  / P   \\  |R| \n"
                         + " |  R    | |K| \n"
                         + " |  K    |=| | \n"
                         + "  |@| |@|  | | \n"
                         + "___________|_|_\n";
    string massMedia = "You now control the mass media!\n"+
                       "       ______________ \n" +
                       "      |.------------.|\n" +
                       "      ||  88::%%##  ||\n" +
                       "      ||  88::%%##  ||\n" +
                       "      ||  88::%%##  ||\n" +
                       "  __  ||  88::%%##  ||\n" +
                       " |==| || __________ ||\n" +
                       " |88| |[##] oo O [##]|\n" +
                       " |88| |== sharp =====|\n" +
                       " `--' \"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"";
    string launch = "     _.-^^---....,,--\n" +
                    " _--                  --_\n" +
                    "<                        >)\n" +
                    "|                         |\n" +
                    " \\._                   _./\n" +
                    "    ```--. . , ; .--'''\n" +
                    "       .-=||  | |=-.  Enemy territory\n" +
                    "       `-=#$%&%$#=-'  is now turned\n" +
                    "          | ;  :|     into rubble.\n" +
                    " _____.,-#%&$@%#&#~,._____ \"";
    string bank =   "You now have access to the bank's money!"+
                    " =============================\n" +
                    "||[$(2οο)$][$(2οο)$][$(2οο)$]||\n" +
                    "||[$(2οο)$][$(2οο)$][$(2οο)$]||\n" +
                    "||[$(2οο)$][$(2οο)$][$(2οο)$]||\n" +
                    "||[$(2οο)$][$(2οο)$][$(2οο)$]||\n" +
                    "||[$(2οο)$][$(2οο)$][$(2οο)$]||\n" +
                    "|=============================|";

    void Start () {
		passwordLevel = new string[,]{{"radio", "hear", "watch", "info", "news"}, 
				{"account", "credit", "finance", "deposit", "economy"},
				{"gunfighter", "weaponry", "artillery", "paratroopers","gunpowder"},
				{"explosion", "bombardment","detonation", "destroy", "bigbang"}
		};

        ShowMainMenu();
		}
	// Update is called once per frame
	void Update () {
		
	}

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("#M1T15");
        Terminal.WriteLine("Hello Player!");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Mass Media");
        Terminal.WriteLine("Press 2 for World Bank");
        Terminal.WriteLine("Press 3 for Military Airbase");
        Terminal.WriteLine("Enter your selection");
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Level " + level + ":");
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Hack the Mass Media?");
                break;
            case 2:
                Terminal.WriteLine("Breach the World Bank Security?");
                break;
            case 3:
                Terminal.WriteLine("Access the Military Airbase?");
                break;
            case 4:
                Terminal.WriteLine("     |     | |  Do you want to\n"
                                + "    / \\    | |  launch missiles\n"
                                + "   |--o|===|-|  into the enemy\n"
                                + "   |---|   |P|  territory?\n"
                                + "  / P   \\  |R| \n"
                                + " |  R    | |K| \n"
                                + " |  K    |=| | \n"
                                + "  |@| |@|  | | \n"
                                + "___________|_|_\n");
                break;
        };
        setRandomPassword();
        Terminal.WriteLine("Encrypt the code: " + Shuffle(password));
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
            ShowMainMenu();
        else if (input == "launch")
        {
            level = 4;
            Debug.Log(level);
            StartGame();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }
    void CheckPassword(string input)
    {
        if( input == password)
        {
            ShowWinScreen();
        }
        else
        {
            StartCoroutine(delay("Hacking Failed!"));
        }
    }

    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        switch (level)
        {
            case 1:
                Terminal.WriteLine(massMedia);
                break;
            case 2:
                Terminal.WriteLine(bank);
                break;
            case 3:
                Terminal.WriteLine(nuclearBase);
                break;
            case 4:
                Terminal.WriteLine(launch);
                break;
        }
        StartCoroutine(hint());
    }

	void setRandomPassword(){
        password = passwordLevel[level-1, Random.Range(0,5)];
	}
    string Shuffle(string str)
    {
        char[] array = str.ToCharArray();
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return new string(array);
    }

    IEnumerator delay(string message)
    {
        Terminal.WriteLine(message);
        yield return new WaitForSeconds(1);
        StartGame();

    }

    IEnumerator hint()
    {
        yield return new WaitForSeconds(5);
        Terminal.WriteLine("Enter \"menu\" to return to main menu");
    }
}
