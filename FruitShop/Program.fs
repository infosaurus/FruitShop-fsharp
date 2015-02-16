module Program

open System
open FruitShop

[<Literal>]
let PommeName = "Pomme"
[<Literal>]
let BananeName = "Banane"
[<Literal>]
let CeriseName = "Cerise"

let noReduction = (1, 0)

let pomme = { name = PommeName; cost = 100; number = 1; reduction = noReduction }
let banane = { name = BananeName; cost = 150; number = 1; reduction = noReduction }
let cerise = { name = CeriseName; cost = 75; number = 1; reduction = (2, 20) }

let groupFruits (fruits:FruitGroup list) fruit =
  if (List.exists (fun (f:FruitGroup) -> f.name = fruit.name) fruits)
  then
   List.map (fun f ->
              if (f.name = fruit.name) 
              then
                { f with number = f.number + 1 }
              else 
                f)
            fruits
  else
   fruit :: fruits
    
let addToCart fruit shoppingCart : ShoppingCart =
  match fruit with
  | PommeName -> {shoppingCart with fruits = groupFruits shoppingCart.fruits pomme }
  | BananeName -> {shoppingCart with fruits = groupFruits shoppingCart.fruits banane }
  | CeriseName -> {shoppingCart with fruits = groupFruits shoppingCart.fruits cerise }
  | _ -> shoppingCart

[<EntryPoint>]
let main argv =
    let mutable input = "" 
    let mutable cart = ShoppingCart.Empty
    while input <> "q" do
      input <- Console.ReadLine()
      cart <- addToCart input cart
      printfn "%i" cart.total
    0 // return an integer exit code
