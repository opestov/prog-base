// call 'vis.exe 09'
open System
open System.Drawing
open System.IO
open System.Windows.Forms

let VWIDTH = 700
let VHEIGHT = 700

let XMIN, XMAX = 0, 700
let YMIN, YMAX = -1000, 1000

let form = new Form(ClientSize=Size(VWIDTH, VHEIGHT))
form.Show()

let scalex p = p*VWIDTH/(XMAX-XMIN)
let scaley p = p*VHEIGHT/(YMAX-YMIN)
let coordx p = scalex (p-XMIN)
let coordy p = scaley (p-YMIN)

let fill_rectangle (x, y) (color : Color) = 
  use graphics = form.CreateGraphics()
  let brush = new SolidBrush(color)
  let nh = scaley (y-YMIN)
  graphics.FillRectangle(brush, coordx x, VHEIGHT-nh, scalex 1, nh) 

do
  use inf = File.OpenText(Environment.GetCommandLineArgs().[1])
  let n = int(inf.ReadLine())
  let a = inf.ReadLine().Split() |> Array.map int
  for i in {0..n-1} do
    fill_rectangle (i, a.[i]) (Color.FromArgb(100+20*(i%2), 100+20*(i%2), 100+20*(i%2)))

  Application.Run(form)
