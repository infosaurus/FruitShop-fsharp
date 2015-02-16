module FruitShop

  type FruitGroup = 
    { name: string; cost: int; number: int; reduction: int * int }

    member this.totalCost =
      this.number * this.cost - (this.number / fst this.reduction) * (snd this.reduction)
      

  type ShoppingCart = 
    { fruits : FruitGroup list; }

    member this.total =
      List.fold (fun x (f:FruitGroup) -> f.totalCost + x) 0 this.fruits

    static member Empty = 
      { fruits = List.empty; }