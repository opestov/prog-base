// call 'vis.exe 09'
open System
open System.Drawing
open System.IO
open System.Windows.Forms

let SIZE = 700
let A1, A2 = -2000, 2000
let DA = A2-A1+1
let B1, B2 = 0, SIZE
let DB = B2-B1+1

let form = new Form(ClientSize=Size(SIZE, SIZE))
form.Show()

let scale x = x*DB/DA
let coord x = B1 + scale (x-A1)

let draw_circle (x,y,r) (color : Color) = 
  use graphics = form.CreateGraphics()
  let pen = new Pen(color)
  graphics.DrawEllipse(pen, coord (x-r), coord (y-r), scale (2*r), scale (2*r))

let draw_rectangle () =
  use graphics = form.CreateGraphics()
  let pen = new Pen(Color.Black, 1.0f)
  graphics.DrawRectangle(pen, coord -1000, coord -1000, scale 2000, scale 2000)
  
do
  draw_rectangle ()  
  
  use inf = File.OpenText(Environment.GetCommandLineArgs().[1])
  let n = int(inf.ReadLine())
  for i in {0..n-1} do
    let [|x;y;r|] = inf.ReadLine().Split(' ') |> Array.map int
    draw_circle (x, y, r) (Color.IndianRed)

  Application.Run(form)
