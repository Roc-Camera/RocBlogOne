using Microsoft.JSInterop;
using System.Text.Json;
using System.Timers;

namespace Demo3.Pages.Apps
{
    public partial class Watch
    {
         private bool isPlay;
        private string isClick = "none";
        private string levelWidth = "400px";
        private string overString;
        private int excessNum = 38;
        private double score = 0;
        private int cheatNum = 0;
        private int randomIntA = 0;
        private int randomIntB = 0;
        private int randomNum = 0;
        private double difficultNum = 1;
        private string randomClass;
        private Random random = new Random();
        private List<string> animalEmoji = new List<string>()
        {
            "🐶", "🐶",
            "🐺", "🐺",
            "🐮", "🐮",
            "🦊", "🦊",
            "🐱", "🐱",
            "🦁", "🦁",
            "🐯", "🐯",
            "🐹", "🐹",
        };

        private List<string> shuffledAnimals = new List<string>();
        private List<double> rankLists = new();
        private int matchesFound = 0;
        private System.Timers.Timer aTimer;
        private int counter = 100;

        protected override async Task OnInitializedAsync()
        {
            string jsonList = JsonSerializer.Serialize(rankLists);
            Console.WriteLine(jsonList);
            aTimer = new System.Timers.Timer(1000);
            SetUpGame();
        }

        private void SetUpGame()
        {
            Random random = new Random();
            shuffledAnimals = animalEmoji
                .OrderBy(item => random.Next())
                .ToList();
            matchesFound = 0;
        }

        string lastAnimalFound = string.Empty;
        string lastDescription = string.Empty;

        private async Task ButtonClickAsync(string animal, string animalDescription)
        {
            Console.WriteLine(lastAnimalFound);
            Console.WriteLine(levelWidth);
            Console.WriteLine(excessNum);
            if ((levelWidth == "400px" && excessNum == 38) || (levelWidth == "600px" && excessNum == 78))
            {
                Console.WriteLine("计时开始");
                StartTime();
            }
            if (randomClass != null)
            {
                await JS.InvokeVoidAsync("closePreRandom", randomClass);
            }
            if (excessNum > 0)
            {
                excessNum--;
            }
            if (lastAnimalFound == string.Empty)
            {

                // First selection of the pair.
                lastAnimalFound = animal;
                lastDescription = animalDescription;
            }
            else if ((lastAnimalFound == animal) && (animalDescription != lastDescription))
            {
                // Match found! Reset for next pair.
                lastAnimalFound = string.Empty;
                // Replace found animals with empty sting to hide them.
                shuffledAnimals = shuffledAnimals
                    .Select(a => a.Replace(animal, string.Empty))
                    .ToList();

                matchesFound++;
                if (levelWidth == "400px" && matchesFound == 8 || levelWidth == "600px" && matchesFound == 18)
                {
                    randomClass = null;
                    isPlay = false;
                    isClick = "none";
                    aTimer.Elapsed -= CountDownTimer;
                    aTimer.Enabled = false;
                    overString = "胜利，继续游戏?";
                    score = counter * 10 * difficultNum - cheatNum * 20;
                    rankLists.Add(score);
                    SetUpGame();
                }
            }
            else
            {
                // User selected a pair that don't match.
                // Reset selection.
                lastAnimalFound = string.Empty;
            }
            if (excessNum == 0)
            {
                randomClass = null;
                isPlay = false;
                isClick = "none";
                aTimer.Elapsed -= CountDownTimer;
                aTimer.Enabled = false;
                overString = "Defeat, Game Over";
                //失败后分数清0
                if (levelWidth == "400px" && matchesFound == 8 || levelWidth == "600px" && matchesFound == 18)
                {
                    score = counter * 10 * difficultNum - cheatNum * 20;
                }
                else
                {
                    score = 0;
                }
                rankLists.Add(score);
                StateHasChanged();
            }
        }
        private void StartTime()
        {

            aTimer.Elapsed += CountDownTimer;
            aTimer.Enabled = true;
        }
        private void CountDownTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (counter > 0)
            {
                counter -= 1;
            }
            else
            {
                aTimer.Elapsed -= CountDownTimer;
                aTimer.Enabled = false;
                //倒计时结束后需要触发的功能
                isPlay = false;
                randomClass = null;
                isClick = "none";
                overString = "失败，游戏结束！";
               //失败后分数清0
                if (levelWidth == "400px" && matchesFound == 8 || levelWidth == "600px" && matchesFound == 18)
                {
                    score = counter * 10 * difficultNum - cheatNum * 20;
                }
                else
                {
                    score = 0;
                }
                rankLists.Add(score);
            }
            InvokeAsync(StateHasChanged);//强制刷新
        }

        private async Task SelectEasyAsync()
        {
            difficultNum = 1;
            if (aTimer.Enabled == true)
            {
                aTimer.Elapsed -= CountDownTimer;
                aTimer.Enabled = false;
            }
            cheatNum = 0;
            if (randomClass != null)
            {
                await JS.InvokeVoidAsync("closePreRandom", randomClass);
            }
            animalEmoji = new List<string>()
            {
                "🐶", "🐶",
                "🐺", "🐺",
                "🐮", "🐮",
                "🦊", "🦊",
                "🐱", "🐱",
                "🦁", "🦁",
                "🐯", "🐯",
                "🐹", "🐹",
            };
            SetUpGame();
            excessNum = 38;
            levelWidth = "400px";
            isClick = "auto";
            counter = 100;
            isPlay = true;
        }
        private async Task SelectHardAsync()
        {
            difficultNum = 1.5;
            if (aTimer.Enabled == true)
            {
                aTimer.Elapsed -= CountDownTimer;
                aTimer.Enabled = false;
            }
            cheatNum = 0;
            if (randomClass != null)
            {
                await JS.InvokeVoidAsync("closePreRandom", randomClass);
            }
            animalEmoji = new List<string>()
            {
                "🐶", "🐶",
                "🐺", "🐺",
                "🐮", "🐮",
                "🦊", "🦊",
                "🐱", "🐱",
                "🦁", "🦁",
                "🐯", "🐯",
                "🐹", "🐹",
                "🐠", "🐠",
                "🦔", "🦔",
                "🙊", "🙊",
                "🦅", "🦅",
                "🦈", "🦈",
                "🐉", "🐉",
                "🐇", "🐇",
                "🚀", "🚀",
                "🤡", "🤡",
                "🦄", "🦄",
            };
            SetUpGame();
            excessNum = 78;
            levelWidth = "670px";
            isClick = "auto";
            counter = 100;
            isPlay = true;
            StateHasChanged();
        }
        string Message { get; set; } = string.Empty;

        private async void SelectCheat()
        {
            if (isPlay)
            {
                //记录作弊次数
                cheatNum++;
                //先判断是easy还是hard ，easy,hard不同levelWidth不同 范围不同
                if (levelWidth == "400px")
                {
                    randomIntA = 0;
                    randomIntB = 15;
                }
                else
                {
                    randomIntA = 0;
                    randomIntB = 35;
                }
                //在范围内选出一个随机数
                randomNum = random.Next(randomIntA, randomIntB);
                //每个随机数对应着cheat{animalNumber} class 让该class的属性为可见 就实现了翻转
                randomClass = $"cheat{randomNum}";
                Console.WriteLine("----" + cheatNum);
                lastDescription = $"Button #{randomNum}";
                Console.WriteLine(randomClass);
                await JS.InvokeVoidAsync("displayRandom", randomClass);
            }
            else
            {
                await JS.InvokeVoidAsync("ScriptAlert", "游戏开始前无法使用作弊功能");
            }
        }
    }
}
