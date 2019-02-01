using System;

namespace Dojodachi.Models
{
    public class Pet
    {
        public int Fullness { get; set; }
        public int Happiness { get; set; }
        public int Energy { get; set; }
        public int Meals { get; set; }
        public String State { get; set; }
        
        public String Action { get; set; }
        Random rnd = new Random();

        public Pet(int fullness = 20, int happiness = 20, int energy = 50, int meals = 3){
            Fullness = fullness;
            Happiness = happiness;
            Energy = energy;
            Meals = meals;
            State = "Satisfied";
        }

        public void Feed(){
            
            if(Meals > 0) {
                    Action = " You fed your dojoichi! ";
                    if(rnd.Next(0,100) > 25) {
                        int num = rnd.Next(5,10);
                        Fullness = Fullness + num;
                        Action = Action + "Fulness +"+num.ToString()+", Meals -1";
                        
                        State = "Happy";
                    } else {
                        State = "Sad";
                        Action = Action + "but it didnt eat. Fulness +0, Meals -1";
                    }
                    
                    Meals--;
                } else {
                    Action =" You have no food!";
                }
            GetStatus();
        }

        public void Play(){
            if(Energy > 0) {
                Action = " You played with your dojoichi! ";
                if(rnd.Next(0,100) > 25)  {
                    int num = rnd.Next(5,10);
                    Happiness = Happiness + num;
                    State = "Happy";
                    Action = Action + "happiness +"+num.ToString()+", Energy -5";
                } else {
                    State = "Sad";
                    Action = Action + "but it didnt want to. Happiness +0, Energy -5";
                }
                Energy = Energy - 5;
            }
            GetStatus();
        }

        public void Work(){
            if(Energy > 0) {
                int num = rnd.Next(1,3);
                Energy = Energy - 5;
                Meals = Meals + num;

                Action = " You worked with your dojoichi! Energy -5, Meals +"+num.ToString();
            }
            GetStatus();

        }

        public void Sleep(){
            if(Fullness > 0 && Happiness > 0) {
                Energy = Energy + 15;
                Fullness = Fullness - 5;
                Happiness = Happiness - 5;

                Action = " You slept with your dojoichi! Energy +15, Fullness -5, Happiness -5";
            }
            GetStatus();
        }

        public void GetStatus() {
            if (Energy >= 100 && Fullness >= 100 && Happiness >= 100)
            {
                State = "Win";
                Action = "Congratulations! You Win!";
            }
            else if(Energy <= 0 || Fullness <= 0 || Happiness <= 0) 
            {
                
                State = "Loose";
                Action = "Your dojo has passed away...";
            }
        }
    }
}
