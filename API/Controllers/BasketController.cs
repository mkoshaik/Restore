using System;
using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class BasketController(StoreContext context) : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<BasketDto>> GetBasket()
    {
              var basket = await RetrieveBasket();

 
          if(basket is null) return NoContent();
          
          return basket.ToDto();

    }


   [HttpPost]

   public async Task<ActionResult> AddItemToBasket(int productId, int quantity)
    {
       //Get Basket
       var basket = await RetrieveBasket();
        
        //Create Basket
        basket ??= CreaeteBasket();


        //Get Product
        var product = await context.Products.FindAsync(productId);

        if(product == null ) return BadRequest("problem adding item to basket");

        basket.AddItem(product, quantity);

        var result = await context.SaveChangesAsync() > 0;

        if(result) return CreatedAtAction(nameof(GetBasket), basket.ToDto());

        return BadRequest("problem updating basket");


        
   }


    [HttpDelete]
        
         public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
          {
             //Get basket
             var basket = await RetrieveBasket();
            
             //remove product from basket 

              if(basket is null) return BadRequest("couldn't find basket");

             basket.RemoveItem(productId, quantity);
             //save changes
              var result = await context.SaveChangesAsync() > 0;

          if(result) return Ok();;

            
             
             return BadRequest("problem deleting basket"); 
          } 
  

          private Basket CreaeteBasket()
          {

             var basketId = Guid.NewGuid().ToString();
             var cookieOptions = new CookieOptions
             {
                 IsEssential = true,
                 Expires = DateTime.UtcNow.AddDays(30)
             };

            Response.Cookies.Append("basketId", basketId, cookieOptions);

            var basket = new Basket {BasketId = basketId};
            context.Baskets.Add(basket);
            return basket;
          }

   private async Task<Basket?> RetrieveBasket()
    {
        return await context.Baskets
        .Include(x => x.Items)
        .ThenInclude(x => x.Product)
        .FirstOrDefaultAsync(x => x.BasketId == Request.Cookies["basketId"]);


    }



}
