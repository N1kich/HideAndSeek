using Hide_and_Seek;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House_Application
{
    public partial class Form1 : Form
    {
        RoomWithDoor livingRoom ;
        RoomWithHidingPlace diningRoom ;
        RoomWithDoor kitchenRoom ;
        OutsideWithHidingPlace gardenOutside ;
        OutsideWithDoor frontYard ;
        OutsideWithDoor backYard;
        Room ladder;
        RoomWithHidingPlace upstairs;
        RoomWithHidingPlace smallBedroom;
        RoomWithHidingPlace bigBedroom;
        RoomWithHidingPlace bathRoom;
        OutsideWithHidingPlace garage;
        Opponent opponent;
        int Moves;
        int HidingPlaces;
        Location currentLocation;

        public void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Гостиная", "Старинный ковер"," За дверью", "Дубовая дверь с латунной ручкой");
            diningRoom = new RoomWithHidingPlace("Столовая", "Хрустальная люстра", "В высоком шкафу");
            kitchenRoom = new RoomWithDoor("Кухня", "Плита из нержавеющей стали","В сундуке", "Сетчатая дверь");
            gardenOutside = new OutsideWithHidingPlace(false, "Сад", "В сарае");
            frontYard = new OutsideWithDoor("Лужайка", false, "Дубовая дверь с латунной ручкой");
            backYard = new OutsideWithDoor("Задний двор", true, "Сетчатая дверь");
            smallBedroom = new RoomWithHidingPlace(" Малая спальня ", " Набор для игры в Го ", " Место под малой кроватью ");
            bigBedroom = new RoomWithHidingPlace(" Большая спальня ", " Семейное фото с Бали ", " Место под большой кроватью ");
            ladder = new Room(" Лестница, ведущая на второй этаж ", " Резные деревянные перила ");
            upstairs = new RoomWithHidingPlace(" Коридор второго этажа ", " Картина с собакой ", " Шкаф ");
            bathRoom = new RoomWithHidingPlace(" Ванная ", "Умывальный набор ", " Душ ");
            garage = new OutsideWithHidingPlace(false, " Гараж ", " Гараж ");

            livingRoom.Exists = new Location[] { diningRoom };
            diningRoom.Exists = new Location[] { livingRoom, kitchenRoom, ladder };
            kitchenRoom.Exists = new Location[] { diningRoom };
            gardenOutside.Exists = new Location[] { backYard, frontYard };
            frontYard.Exists = new Location[] { gardenOutside, backYard, garage };
            backYard.Exists = new Location[] { gardenOutside, frontYard, garage };
            smallBedroom.Exists = new Location[] { upstairs };
            bigBedroom.Exists = new Location[] { upstairs };
            ladder.Exists = new Location[] { livingRoom, upstairs };
            upstairs.Exists = new Location[] { ladder, smallBedroom, bigBedroom, bathRoom };
            bathRoom.Exists = new Location[] { upstairs };
            garage.Exists = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchenRoom.DoorLocation = backYard;
            backYard.DoorLocation = kitchenRoom;
        }
        
        void ResetGame(bool check)
        {
            if (check)
            {
                if (Moves > 10)
                {
                    description.Text = "Вы проиграли! Вы не смогли отыскать соперника за 10 ходов. Соперник находился в " + opponent.Mylocation.Name;
                }
                else
                {
                    description.Text = "Вы победили! Соперник был в " + opponent.Mylocation.Name + ". Вы нашли его на " + Moves + " ходу." + " Вы проверили "
                        + HidingPlaces + " укромных местечек";
                }
            }
            exits.Visible = false;
            goHere.Visible = false;
            checkButton.Visible = false;
            goThroughTheDoor.Visible = false;
            hideButton.Visible = true;
            Moves = 0;
        }
        void MoveToANewLocation(Location currentLocation)
        {
            ++Moves;
            this.currentLocation = currentLocation;
            ReDrawForm();
            
        }

        void ReDrawForm()
        {
            exits.Items.Clear();
            for (int i = 0; i < this.currentLocation.Exists.Length; i++)
            {
                exits.Items.Add(this.currentLocation.Exists[i].Name);
            }
            exits.SelectedIndex = 0;
            description.Text = this.currentLocation.Description + "\n # Число ходов \n" + Moves;
            if (this.currentLocation is IHasExteriorDoor)
            {
                goThroughTheDoor.Visible = true;
            }
            else
                goThroughTheDoor.Visible = false;
            if (this.currentLocation is IHidingPlace)
            {
                IHidingPlace hidePlace = currentLocation as IHidingPlace;
                checkButton.Text = hidePlace.HidingPlace;
                checkButton.Visible = true;
            }
            else
                checkButton.Visible = false;
            exits.Visible = true;
            goHere.Visible = true;
        }
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            ResetGame(false);
            opponent = new Opponent(livingRoom);
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exists[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);

        }

        private void description_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void checkButton_Click(object sender, EventArgs e)
        {
            HidingPlaces++;
            if (opponent.Check(currentLocation))
                ResetGame(true);
            else
                description.Text = " В этой комнате соперника нет, попробуйте поискать в другом помещении.";

        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            hideButton.Visible = false;
            for (int i = 10; i >= 1; i--)
            {
                description.Text = "\nОсталось " + i + " секунд, чтобы спрятаться\n";
                opponent.Move();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);

            }
            
            description.Text = "Игра началась!";
             Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            MoveToANewLocation(livingRoom);
            


        }
    }
}
