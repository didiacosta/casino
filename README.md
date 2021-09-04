# API casino
## EndPoints
- **[servidor]/api/roulette/add/** : Endpoint tipo **POST** que permite crear nuevas ruletas retornando un objeto respuesta que contiene un mensaje y el id de la ruleta creada
![Endpoint1](https://user-images.githubusercontent.com/11274780/132106700-858cd160-3258-40b4-873d-ed26794e3e24.PNG)
- **[servidor:puerto]/api/roulette/open/1/** : Endpoint tipo **GET** que permite realizar la apertura de una ruleta. Este endpoint recibe por parametro el id de la ruleta que se desea aperturar. Como respuesta se obtiene un objeto que contiene un mensaje con el atributo message, y el estado de la operación de apertura con el atributo data. 
  > si **data** es igual a 1, entonces la ruleta fue aperturada correctamente.
  > 
  > Si **data** es igual a 0, entonces la ruleta no pudo ser aperturada correctamente.

  ![Endpoint2](https://user-images.githubusercontent.com/11274780/132106891-6bfab34b-f08e-4637-b52e-b9543e39cd20.PNG)

- **[servidor]/api/roulette/tobet/1/** : Enpoint tipo **POST** que permite realizar la apuesta a un numero o color en la ruleta. Este endpoint recibe los siguientes parametros:
  -  Por url se recibe el id de la ruleta con la cual se desea apostar. Esta ruleta debe estar abierta para poder realizar la apuesta.
  -  se recibe el objeto JSON que representa la apuesta. Dicho objeto debe tener la siguiente estructura:
    {
    "Id": 0,   
    "UserId": 1,
    "BetType": 2,
    "BetNumber": 15,
    "BetColor" : 1,
    "Amount" : 4000
    }
    El endpoint realiza las validaciones pertinentes de acuerdo a los siguientes criterios:
      - El atributo BetType solo puede contener uno de los siguientes valores: 1 => corresponde a apuesta por numero, 2 => Corresponde a apuesta por color
      - El atributo BetColor solo puede ser igual a uno de los siguientes valores: 1 => corresponde al color Rojo, 0 => Corresponde al valor Negro
      - El atributo BetNumber debe ser un numero entero entre 0 y 36
      - El atributo Amount debe ser Mayor a 0 y menor a 10.000, debido a que el valor maximo de apuesta es 10.000 dolares
  
  ![Endpoint3](https://user-images.githubusercontent.com/11274780/132107211-544e0a10-2fd3-4eb0-aea5-45e3a4bdfb45.PNG)

- **[servidor]/api/roulette/close/1/** : Enpoint tipo **POST** que permite cerrar las apuestas de una ruleta(se recibe su id por la url), retornando todas las apuestas realizadas desde su apertura hasta su cierre. Cada apuesta retornada tiene un atributo llamado **result** que sera positivo si se gana la apuesta y negativo si la pierde, cuando result es positivo se tuvo en cuenta la ganacia de la apuesta:
  ![Endpoint4](https://user-images.githubusercontent.com/11274780/132107455-371fbfe7-37a8-4405-9adf-9a8691d7d74d.PNG)
    > Si la apuesta se realiza por color, result sera igual a 1.8 veces el dinero apostado, indicado en el atributo amount de la apuesta.
    > Si la apuesta se realiza por numero, result sera igual a 5 veces el dinero apostado, indicado en el atribuuto amount de la apuesta.
    > El numero ganador es determinado automaticamente cuando se cierra la ruleta.

- **[servidor]/api/roulette/** : Endpoint tipo **GET** que retorna la lista de ruletas creadas y sus estados, los cuales se determinan numericamente de la siguiente manera:
  - Si status es igual a 1, entonces la ruleta esta abierta.
  - Si status es igual a 0, entonces la ruleta esta cerrada.
   ![Endpoint5](https://user-images.githubusercontent.com/11274780/132107664-fc97b363-2cb8-43e3-95cf-71c0a8eb7497.PNG)
