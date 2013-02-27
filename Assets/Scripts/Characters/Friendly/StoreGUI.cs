using UnityEngine; 
using System.Collections; 
 
public class StoreGUI : MonoBehaviour { 
#region DECLARED VARIABLES
    private Transform myTransform;              // NPC Transform
    private Transform playerTransform;          // Player Transform
    private float playerDistance;               // distance between Player and NPC
 
    public bool displayStore = true;            // show the store
    
    // define and create our GUI delegate
    private delegate void GUIMethod(); 
    private GUIMethod currentGUIMethod; 
    private Vector2 scrollPosition = Vector2.zero;
    
    // Array with the Itens
    public ArrayList itensArray = new ArrayList();
    public ArrayList itensPriceArray = new ArrayList();
 
    // Array with the Armor
    public ArrayList armorsArray = new ArrayList();
    public ArrayList armorsPriceArray = new ArrayList();
    
    // Array with the Weapons
    public ArrayList weaponsArray = new ArrayList();
    public ArrayList weaponsPriceArray = new ArrayList();
    
    private int amount = 1;                     //amount of itens to buy
    private int totalPrice;                     //total price of itens to buy
    private string selectedItem = "";           // selected item from the store
    private int selectedItemPrice;              // price of the selected item from the store
    
    private Color lerpedColor;                  //just a test
#endregion DECLARED VARIABLES
 
    // Use this for initialization
    void Start () { 
            
        GameObject go = GameObject.FindGameObjectWithTag("Player"); //find the GameObject w/ "Player" TAG
        playerTransform = go.transform;                             //and stores its Transform
    
        myTransform = transform;                // NPC transform;
                
        this.currentGUIMethod = itensMenu;      // start with the main menu GUI
 
        selectedItem = "";                      //sets the selected item to null
        
        addStuffToArrays();                     // fills the arrays with the Items
    }
 
    //Update is called Once per frame
    void Update(){
        
        //this is just a test
        lerpedColor = Color.Lerp(Color.green, Color.red, Time.time / 10);
        
        // stores the Distancie between the NPC and the player
        playerDistance = Vector3.Distance(myTransform.position, playerTransform.position);
        
        // if the playerDistance is bigger than 4, close the store
        if(playerDistance > 4){         
            displayStore = false;
        }
    }
    
    //Displays the store
    public void OnMouseUpAsButton() {       // When the NPC is clicked...
        if(playerDistance<4){               // and if playerDistance is lesser than 4...
            displayStore = true;            // then Displays the StoreGUI. 
        }
    }
 
#region OnGUI
    // Update is called once per frame 
    void OnGUI () {
    
        //Displays the store
        if(displayStore){
        
            //Text Item
            GUI.Label (new Rect (20, 40 , 230, 30), "Item");
            //Text Price
            GUI.Label (new Rect (250, 40, 40, 30), "Price");
        
            //button Exit
            if(GUI.Button (new Rect(20 + 100+100+100, 5, 100, 30), "Exit Store")){
                displayStore = false;
            }
    
            this.currentGUIMethod(); 
            
            // Area with selected item, amount, total price...
            GUILayout.BeginArea(new Rect( 20, 270, 400, 100));
            
            GUILayout.BeginVertical("box");
            
            GUILayout.BeginHorizontal("Label");
            //Text Item
            GUILayout.Box ("Selected Item", GUILayout.Width(110));
            //Text Amount
            GUILayout.Box ("Amount");
            //Text Total
            GUILayout.Box ("Total");
            GUILayout.EndHorizontal();
            
            
            GUILayout.BeginHorizontal("box");
 
            // Box with Item Name
            GUILayout.Box  (selectedItem.ToString(), GUILayout.Width(110));
 
            // Box with Amount
            GUILayout.Box  (" X " + amount.ToString(), GUILayout.Width(50));
            
            //Button Amount plus
            if(GUILayout.RepeatButton (" + ")){
                amount++;
            }
            //button Amount minus
            if(GUILayout.RepeatButton (" - ")){
                amount--;
            }
            //box Total Price
            GUI.color = lerpedColor;
            GUILayout.Box (totalPrice.ToString(), GUILayout.Width(80));
            
            //button Buy
            if(GUILayout.Button ("Buy")){
                addItemToInventory();
            }
            
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.EndArea();
            
        }   //ends the displayStore IF
    }
#endregion OnGUI
    
    /*#---------------------- REGION MENUS----------------------------#*/
    
#region ITENS MENU  - called inside OnGUI   
    public void itensMenu() { 
        
        GUI.Box (new Rect (20, 5, 100, 30), "Itens Menu");  // Box with the Menu Title
        
        //Scroll Area with the Itens displayed Inside                                           // The scroll is dinamic generated by the size of the array
        scrollPosition = GUI.BeginScrollView(new Rect(20, 60, 300, 200), scrollPosition, new Rect(0, 0, 120, itensArray.Count * 30));
            displayItens();
        GUI.EndScrollView();
        
        if (GUI.Button (new Rect (20 + 100, 5, 100, 30), "Armors Menu")) {
            switchMenuForArmorsButton();                //Switch for Armors Menu
        } 
        
        if (GUI.Button (new Rect (20 + 100 + 100, 5, 100, 30), "Weapons Menu")) {
            switchMenuForWeaponsButton();                //Switch for Weapons Menu
        } 
        
    } 
#endregion ITENS MENU
 
#region ARMORS MENU - called inside OnGUI
    private void armorsMenu(){
        
        GUI.Box (new Rect (20, 5, 100, 30), "Armors Menu");             // Box with the MenuTitle
        
        //Scroll Area with the Itens displayed Inside                                           // The scroll is dinamic generated by the size of the array
        scrollPosition = GUI.BeginScrollView(new Rect(20, 60, 300, 200), scrollPosition, new Rect(0, 0, 120, armorsArray.Count * 30));
            displayArmor();
        GUI.EndScrollView();
        
        if (GUI.Button (new Rect (20 + 100, 5, 100, 30), "Itens Menu")) {
            switchMenuForItensButton();                 // Switch for Itens Menu
        } 
        
        if (GUI.Button (new Rect (20 + 100 + 100, 5, 100, 30), "Weapons Menu")) { 
            switchMenuForWeaponsButton();                //Switch for Weapons Menu
        } 
    }  
#endregion ARMOR MENU       
    
#region Weapons MENU - called inside OnGUI
    private void weaponsMenu(){
 
        GUI.Box (new Rect (20, 5, 100, 30), "Weapons Menu");             // Box with the MenuTitle
        
        //Scroll Area with the Itens displayed Inside                                           // The scroll is dinamic generated by the size of the array
        scrollPosition = GUI.BeginScrollView(new Rect(20, 60, 300, 200), scrollPosition, new Rect(0, 0, 120, weaponsArray.Count * 30));
            displayWeapon();
        GUI.EndScrollView();
        
        if (GUI.Button (new Rect (20 + 100, 5, 100, 30), "Itens Menu")) {       
            switchMenuForItensButton();                 // Switch for Itens Menu
        } 
        
 
        if (GUI.Button (new Rect (20 + 100 + 100, 5, 100, 30), "Armors Menu")) { 
            switchMenuForArmorsButton();                //Switch for Armors Menu
        } 
    }    
#endregion Weapons MENU   
 
#region SWITCH MENU BUTTOMs - called inside ITENS, ARMORS AND weapons MENUS()
    void switchMenuForItensButton(){
        this.currentGUIMethod = itensMenu;              // switch to Itens Menu
        amount = 1;                                     // resets the amount of itens selected
    }
 
    void switchMenuForArmorsButton(){
        this.currentGUIMethod = armorsMenu;             // switch to Armors Menu
        amount = 1;                                     // resets the amount of itens selected
    }
 
    void switchMenuForWeaponsButton(){
        this.currentGUIMethod = weaponsMenu;             // switch to Weapons Menu
        amount = 1;                                     // resets the amount of itens selected
    }
#endregion  SWITCH MENU BUTTOMs
 
    /*#---------------------- END REGION MENUS-------------------------#*/
    
    /*#---------------------- REGION DISPLAY ITENS LOOPS----------------------------#*/
#region DISPLAY ITENS LOOP  - called inside ItensMenu()
        public void displayItens() {
                            
            // Loop to display all the itensArray of the itensArray
            for(int cnt = 0; cnt < itensArray.Count; cnt++){
            
                //Buttom with Item Name
                if(GUI.Button (new Rect (0, 30 * (cnt), 230, 30), itensArray[cnt].ToString(), "box")){
                    
                    // Selects the item and it´s price
                    selectedItem = itensArray[cnt].ToString();
                    selectedItemPrice = (int)(itensPriceArray[cnt]);
                    
                    // resets the amount of itens selected
                    amount = 1;
                }
            
                // Displays the Item Price
                GUI.Box (new Rect (230, 30 * (cnt), 50, 30), itensPriceArray[cnt].ToString());
                
                // calculates the total price
                totalPrice = amount * (int)(selectedItemPrice);
            } 
        }
#endregion DISPLAY ITENS LOOP
        
#region DISPLAY ARMORS LOOP - called inside ArmorsMenu()
        public void displayArmor() {
            
            // Loop to display all the itensArray of the array
            for(int cnt = 0; cnt < armorsArray.Count; cnt++){
 
                //Buttom with Armor Name
                if(GUI.Button (new Rect (0, 30 * (cnt), 230, 30), armorsArray[cnt].ToString(), "box")){
                    
                    // Selects the armor and it´s price
                    selectedItem = armorsArray[cnt].ToString();
                    selectedItemPrice = (int)(armorsPriceArray[cnt]);
                    
                    // resets the amount of itens selected
                    amount = 1;
                }
                
                // Displays the Item Price
                GUI.Box (new Rect (230, 30 * (cnt), 50, 30), armorsPriceArray[cnt].ToString());
                
                // calculates the total price
                totalPrice = amount * (int)(selectedItemPrice);
            } 
        }
#endregion DISPLAY ARMOR LOOP
 
#region DISPLAY weapons LOOP - called inside WeaponsMenu()
        public void displayWeapon() {
            
            // Loop to display all the itensArray of the array
            for(int cnt = 0; cnt < weaponsArray.Count; cnt++){
 
                //Buttom with Armor Name
                if(GUI.Button (new Rect (0, 30 * (cnt), 230, 30), weaponsArray[cnt].ToString(), "box")){
                    
                    // Selects the armor and it´s price
                    selectedItem = weaponsArray[cnt].ToString();
                    selectedItemPrice = (int)(weaponsPriceArray[cnt]);
                    
                    // resets the amount of itens selected
                    amount = 1;
                }
                
                // Displays the Item Price
                GUI.Box (new Rect (230, 30 * (cnt), 50, 30), weaponsPriceArray[cnt].ToString());
                
                // calculates the total price
                totalPrice = amount * (int)(selectedItemPrice);
            } 
        }
#endregion DISPLAY Weapon LOOP
 
    /*#---------------------- END REGION DISPLAY ITENS LOOPS------------------------#*/
 
 
 
#region ADD ITEM TO INVENTORY - called inside OnGUI - "buy" button  
    public void addItemToInventory(){           // Method for the buy buttom
        
        if(selectedItem != ""){                 //se selectedItem for diferente de null
            print("Bought Item!");
            // To Add Item X amount; - Use a loop   
            /* 
            for(int cnt = 0; cnt < amount; cnt++){
                addItemToInventory(selectedItem);
            }
            
            curGold - totalPrice;
            */
        }
    }
#endregion ADD ITEM TO INVENTORY
    
#region ADD STUFF TO ARRAYS - called inside Start()
    // Fills itensArrays, armorsArray, weaponsArray, and PricesArray with the itens
    private void addStuffToArrays(){
    
    // add itens to the itensArray
        itensArray.Add("Health Potion");
        itensArray.Add("Mana Potion");
        itensArray.Add("Mega-HealthPotion");
        itensArray.Add("Mega-ManaPotion");
            
    // add itens to the itensPriceArray     
        itensPriceArray.Add(25);
        itensPriceArray.Add(25);
        itensPriceArray.Add(50);
        itensPriceArray.Add(50);
        
    // add itens to the armorsArray
        armorsArray.Add("Leather Coat");
        armorsArray.Add("Gold Shield");
        armorsArray.Add("Platinum Armor");
        
    // add prices to armorsPriceArray
        armorsPriceArray.Add(200);
        armorsPriceArray.Add(1000);
        armorsPriceArray.Add(2000);
        
        
    // add itens to the weaponsArray
        weaponsArray.Add("Wooden Staff");
        weaponsArray.Add("Rod of Ages");
        weaponsArray.Add("Buster Wand");  
        
    // add prices to weaponsPriceArray
        weaponsPriceArray.Add(100);
        weaponsPriceArray.Add(500);
        weaponsPriceArray.Add(1000);
    }
#endregion ADD STUFF TO ARRAYS
}