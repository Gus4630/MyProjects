  /*
      CSCI 2408 Computer Graphics Fall 2022 
      (c)2022 by Huseyin Salimov 
      Submitted in partial fulfillment of the requirements of the course.
  */
  
/*This is the final result. I couldn't save file to the seed and perform a smooth color change of alive cell after
some period of time. Everyting else that was required I did it.
*/
let x_coordinate, y_coordinate; //this is coordinates of the mouse
let cell = []; //array of cells where i will use it further for initializing my map
cell_counter = 0;
function printMousePos(event) {    //1-st requirement of the task is met here
      x_coordinate = event.clientX; //taking x position of the mouse
      y_coordinate = event.clientY; //taking y position of the mouse

      x_coordinate = Math.floor(x_coordinate / gameOfLife.resolution - 0.5); //I do here the calculation to get the desired position on my map/grid
      y_coordinate = Math.floor(y_coordinate / gameOfLife.resolution - 0.5);

      if(!(x_coordinate < 0 || x_coordinate > 49  || y_coordinate < 0 || y_coordinate > 49)){   
      //if coordinates were less or more than grid, cell would be created out of the map.


      cell.push(new Cell(x_coordinate*gameOfLife.resolution,y_coordinate*gameOfLife.resolution,gameOfLife.resolution));      
      //In the code above we push the coordinates of my Cell class and do calculations in order to get the desired/correct map on the grid;
      cell[cell_counter].is_live = 1; //I am setting cell's live
      cell[cell_counter].was_alive = 1; //it is done for outputing the cells that once were alive
      cell[cell_counter].is_live_previous = 0; //Previous state of cell wasn't alive
      cell[cell_counter].display(); //Drawing cell on the grid
      cell_counter++;                       
      }
}
document.addEventListener("click", printMousePos); //event on clicking the mouse left button



class GameOfLife{

columns; //grid's columns
rows; // grid's rows
resolution = 10 ; //the size of pixels on the grid.
map = []; //My grid of cells

  constructor(){
    
    this.columns = 50; //3-d requirement of the task is met here. 
    this.rows = 50; //Grid is 50x50
    if(this.resolution*this.rows > canvas.width || this.resolution*this.columns >canvas.height){ //this is done to correct the resolution
      
      if(canvas.width/this.columns < canvas.height/this.rows){

        this.resolution = Math.floor(canvas.width/this.columns);
      }
      else{
        this.resolution = Math.floor(canvas.height/this.rows);
      }
    }
      this.initialize_GameOfLife(); //by default we are initializing our map

  }

  

   initialize_GameOfLife() {    //here we add to our map array objects of the class Cell
    
    for (let i = 0; i < this.columns; i++) {
      for (let j = 0; j < this.rows; j++) {        

        this.map[i] = [...(this.map[i] ? this.map[i] : []),
          new Cell(i*this.resolution,j*this.resolution, this.resolution)
        ];        
      }
    }
   }  

   initialize_GameOfLife_WithMouse() {  //1st requirement of the task's continuation
    
    this.columns = 50;
    this.rows = 50;
    if(this.resolution*this.rows > canvas.width || this.resolution*this.columns >canvas.height){ //again resolution correction
      
      if(canvas.width/this.columns < canvas.height/this.rows){

        this.resolution = Math.floor(canvas.width/this.columns);
      }
      else{
        this.resolution = Math.floor(canvas.height/this.rows);
      }
    }
    temp = true; //Here we create temp variable in order to add our map the Cell objects in variable cell 
    for (let i = 0; i < this.columns; i++) { //looping through a map
      for (let j = 0; j < this.rows; j++) { 
        
        for(let c = 0; c < cell.length; c++){ //here we create another for loop for our cell array of objects Cell
        
        if(cell[c].x_i == i*this.resolution && cell[c].j_i == j*this.resolution) 
          {
            //when coordinates of the map and object cell meet we initialize our Cell and change the is_live values.
            //this all will happen when we click on the grid and event is called
            
            this.map[i] = [...(this.map[i] ? this.map[i] : []),
            new Cell(i*this.resolution,j*this.resolution, this.resolution)];
            this.map[i][j].is_live = 1;
            this.map[i][j].was_alive = 1;
            this.map[i][j].is_live_previous = 0;                        
            temp = true;
          }                                    
        }
        if(temp == false){
            //other Cells in the map should remain dead.
          this.map[i] = [...(this.map[i] ? this.map[i] : []),
              new Cell(i*this.resolution,j*this.resolution, this.resolution)
              ];       
              this.map[i][j].is_live = 0;
              this.map[i][j].is_live_previous = 0;
              this.map[i][j].was_alive = 0;
        }
        temp = false;
      }
    }
   }  
    show_cell() { //here we call the method display() of the class Cell in order to draw on the canvas
    for ( let i = 0; i < this.columns;i++) {
      for ( let j = 0; j < this.rows;j++) {
        this.map[i][j].display();
      }
    } 
    
  }  
  
     generate() {  //2-nd requirement of the task is met here. In this method all calculation of the rules happens
      for ( let i = 0; i < this.columns;i++) {
        for ( let j = 0; j < this.rows;j++) {
          this.map[i][j].is_live_previous = this.map[i][j].is_live; 
          /*as we are going to change current is_live property
          we need to write it in is_live previous. It will be is_live's previous state*/
        }
      }


     for (let x = 0; x < this.columns; x++) {
       for (let y = 0; y < this.rows; y++) {         
         
        let neighbors = 0; //here we loop around 3x3 of the cell in order to count neighboors
         for (let i = -1; i <= 1; i++) {
           for (let j = -1; j <= 1; j++) {
             neighbors = neighbors + this.map[(x+i+this.columns)%this.columns][(y+j+this.rows)%this.rows].is_live_previous;
             /*Here we are counting our neighboors. in order to get them correctly
             as a col we add Cell's position which is x then neigboors position which is i then all columns and % columns
             in order to get it, I do that as when the cell reaches the end of the grid, it will come up to the beginning
             same thing is happening with rows
             */
           }
         }
 
       
         neighbors -= this.map[x][y].is_live_previous;//we minus ourselves. As we should not be counted
 
         
         if((this.map[x][y].is_live == 1) && (neighbors <  2)) // Here is where first rule is met
         {
          //Underpopulation
          this.map[x][y].is_live = 0;
          this.map[x][y].was_alive = 1;
         }       
         else if ((this.map[x][y].is_live == 1) && (neighbors >  3))//Third rule
         {
          // Overpopulation
            this.map[x][y].is_live = 0;
            this.map[x][y].was_alive = 1;
         }           
         else if ((this.map[x][y].is_live == 0) && (neighbors == 3)) // Fourth rule
         {
          // Reproduction
          this.map[x][y].is_live = 1;
         }           
          //Second rule of the game is met automatically according to the code above. 
        
       }
       
     }
     
   }

}

  function getRandomIntInclusive(min, max) { //Function for Creating random integers
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1) + min); // The maximum is inclusive and the minimum is inclusive
  }
  function create2DArray(cols, rows) { //Creating 2Dimenional Array
    let arr = new Array(cols);
    for (let i = 0; i < arr.length; i++) {
      arr[i] = new Array(rows);
    }
    return arr;
  }
  function create2DArrayCell(cols, rows, resolution) { //Creating 2Dimensional array of objects belonging to class Cell
    let arr = [];
    for (let i = 0; i < cols; i++) {
      for (let j = 0; j < rows; j++) {
        arr[i] = [...(arr[i] ? arr[i] : []),
          new Cell(i*resolution,j*resolution, resolution)
        ];
      }
    }
  }
  
  class Cell{
     //
    x_i; //cell's x position
    j_i; // cell's y position
    resolution; // size of cells
    is_live; //cell's is_live state
    is_live_previous; //cell's is_live previous state
    was_alive; 
    amount = 0; //I was trying here to create a smooth color transition of the alive cells according to the ticks, but unsuccsessful
    time = new Date().setSeconds(5);
    

    constructor(x_, y_, resolution_){ //initialization
      this.x_i = x_;
      this.j_i = y_;
      this.resolution = resolution_;      
      this.is_live = getRandomIntInclusive(0,1);
      this.was_alive = this.is_live;
      this.is_live_previous = this.is_live;
    }

    

      display() {   //in this part we draw to our canvas
      
      if (this.is_live_previous == 0 && this.is_live == 1) {        
        ctx.fillStyle = colorOfLiveCell;  //Bonus part: we set the desired color of live cells by choosing it
      }
      else if (this.is_live == 1) {
        ctx.fillStyle = 'black'; //Bonus part: we here define the color of the alive cell 
        
      }
      else if (this.is_live_previous == 1 && this.is_live == 0) {
        ctx.fillStyle = colorOfDeadCell; // Bonus part: we set the color of the dead cell
      }
      else if (this.was_alive == 1){
        ctx.fillStyle = '#808080'; //The cell that was alive at some period, changes its color to grey
      }
      else {      
      ctx.fillStyle = '#FFFFFF'; //other cells fill white
      }
      ctx.fillRect(this.x_i, this.j_i, this.resolution - 1, this.resolution - 1); //drawing pixels
      
    }
  }
  
 

  function shadeColor1(color, percent) {	// tried to do color shading for smooth color transition of once  alive cells but unsuccessful
    var num = parseInt(color.slice(1),16), amt = Math.round(2.55 * percent), R = (num >> 16) + amt, G = (num >> 8 & 0x00FF) + amt, B = (num & 0x0000FF) + amt;
    return "#" + (0x1000000 + (R<255?R<1?0:R:255)*0x10000 + (G<255?G<1?0:G:255)*0x100 + (B<255?B<1?0:B:255)).toString(16).slice(1);
} 
  function functionName(){    
    //we set interval on function calling in order to let the program draw on canvas
    if(refreshInterval == undefined)
    {
     refreshInterval = setInterval(function(){
      draw();      
      }, delayTime);
    }
  }
  
  
  function stop(){
    //4-th requirement, when stop is pressed we stop the game
   clearInterval(refreshInterval);
   refreshInterval = undefined;
  }
  function tick_at_a_time(){ //4-th requirement, we go here tick by tick
    stop();
    draw();
  }
function setDelayTime(){ //Bonus part: We take delay from input and set here delay between ticks.
  delayTime = document.getElementById("delayInp").value;  
  stop();
}

  let delayTime = 100; //default tickdelay
  let temp = false;
  let canvas = document.getElementById("canvas"); //we get canvas
  canvas.width = 800;
  canvas.height = 800;
  let ctx = canvas.getContext("2d");
  ctx.lineWidth = 0.5; //setting the line width of the grid outline
  ctx.strokeStyle="#FF0000"; //line color
  let colorOfLiveCell = "#0000ff"; //color of the live cell is set by default in the global to blue
  

  let btn = document.getElementById('startBtn');
  btn.addEventListener("click",functionName);
  let refreshInterval;
  document.getElementById('delayBtn').addEventListener("click", setDelayTime); //events for button clicks

  let colorOfDeadCell = 'red'; //color of the dead cell is set by default in the global to red
  let boolish = false;
  let deadColorInput = document.getElementById('colorOfDeadInp'); 
  deadColorInput.addEventListener("input",function(){ 
    colorOfDeadCell = deadColorInput.value;
   //we take the input from type color in html and set the color of the dead cell.
  });
  
  let liveColorInput = document.getElementById('colorOfLiveInp');
  liveColorInput.addEventListener("input",function(){
  colorOfLiveCell = liveColorInput.value;
  //we take the input from type color in html and set the color of the live cell.
  });


  let gameOfLife = new GameOfLife(); //we create the object of our main class where everything happens
  

  ctx.strokeRect(0, 0, canvas.width - 299, canvas.height - 299); //we draw our grid's outline
  document.getElementById('stopBtn').addEventListener("click",stop); //events for stop and ticks 
  document.getElementById('tickBtn').addEventListener("click",tick_at_a_time);
  function draw() {      
    if(cell.length>0 && temp == false){ 
    //this is when mouse is clicked, then this is called. As when mouse is clicked we push to our let cell the Cell objects.
    //and its length is added
    //we check in our if for temp in order to make this if performed once, as our code is running non stop.
    //as if we dont it will always initialize with_mouse because this draw function is called always to run the game
      gameOfLife.initialize_GameOfLife_WithMouse();
    temp = true;
    
    }
    gameOfLife.generate();//this is where rules are met and calculations happen
    gameOfLife.show_cell(); //this is where we draw on our canvas
     
  }

  
  
  

   
                 
      
    
    
