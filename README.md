# BattleShipTask
Simple simulation of battleship game between two players


# 1 Architektura:

  * Całą aplikacją steruje klasa Grid
  
  * Pola planszy zdecydowałem się przedstawić za pomocą obiektów klasy Square która posiada współżędne i informacje
  o stanie komórki. Pozwoliło mi to łatwo i dynamicznie modyfikować stan komórki
  
  * Plansza jest listą takich komórek Square. Przy inicjalizazji planszy tworzone są puste komórki, a później zapełniane one są statkami
  za pomocą metody ShipPlacemant()
  
  * Metoda ShipPlacemant():
  Wybiera losową komórkę jako "głowę" statku, wybiera losową orientację(pionową, poziomoą) i sprawda czy dany statek się "zmieści" na planszy. 
  Jeśli tak stawiany jest w tym miejscu, jeśli nie funkcja wywoływana jest ponownie.
  
  * Obiekt gridu zapamiętuje w sesji oraz przesyłam jako Json do Komponentu w React: BattleShip.js
  
  Po stworzeniu planszy ze statkami klasa jest gotowa do symulowania gry.
  
# 2 Symulacja:
  Symulacja polega na wywoływaniu metody Shot()

  Metoda Shot() za pomocą stworzonego przeze mnie algorytmu wybiera pole w które chce strzelić i zaznacza je jako trafione.
  Jeśli na tym polu stał statek zaznacza to pole tatku jako zatopione.
  
# 3 Działanie algorytmu:
  Postanowiłem że zaimplemętuję algorytm który nie tylko strzela w losowe pola. Gdy algorytm znajdzie pole na którym znajduje się statek, od razu próbuje go zatopić, podobnie jak zrobiłby to człowiek
  
  Działa to w następujący sposób:
  
  * Na początku algorytm wybiera losowe pola dopóki nie znajdzie statku
  ![Screenshot_1](https://user-images.githubusercontent.com/50641019/116163472-1b985380-a6f8-11eb-976e-f799e8fe8b55.png)
  
  (szare pola reprezentują statki, czerwone chybiony strzał)
  
  * Po znalezieniu statku strzela jedno pole nad znalezionym statkiem strzela w jednym kierunku dopóki nie chybi. Gdy chybi wraca do pola gdzie odkrył statek i zmienia kierunek(tak jak na gifie)
  
  * Po zmianie czterokrotnej zmianie kierunku algorytm wraca do losowego wybierania pól(jak na końcu animacji)
  
  ![Gif1](https://user-images.githubusercontent.com/50641019/116164997-27394980-a6fb-11eb-9be2-d28e664d1596.gif)
  
  (szare: statki, fioletowe: trafiony, czerowne: chybiony)
  
  Symulacja kończy się gdy jeden z graczy zatopi wszystkie statki
  
  
