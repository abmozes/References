#include <iostream>
#include <string>
#include <vector>
#include <string>
#include <iterator>
#include <algorithm>

// A küldetés, hogy a lázadók megsemmisítő csapást mérjenek a Halálcsillagra.
// A Halálcsillag erejét egy részfeladat megoldásával lehet csökkenteni.

class Jedi {
public:
  Jedi(std::string name, std::string rank, int power): name(name), rank(rank), power(power) {}

  std::string get_name() const { return name; }
  std::string get_rank() const { return rank; }
  int get_power() const { return power; }

  void add_power(const int& x) {
    power += x;
  }

private:
  std::string name, rank;
  int power;
};

class JediCouncil {
public:

  void add(Jedi& j) {

    if (j.get_name() != "Anakin") {
      j.add_power(10);
    }
    else {
      j.add_power(5);
    }

    if (j.get_rank() == "Master")
    {
      masters.push_back(j);
    }
    else if (j.get_rank() == "Knight")
    {
      knights.push_back(j);
    }
    else
    {
      padawans.push_back(j);
    }

  }

  int member_number(const std::string& rank) {
    if (rank == "Master")
    {
      return masters.size();
    }
    else if (rank == "Knight")
    {
      knights.size();
    }
    else
    {
      padawans.size();
    }
  }

  void print() {
    std::cout << std::endl << "    Members:" << std::endl;
    std::cout << "Masters:" << std::endl;
    for (const auto& item: masters) {
        std::cout << item.get_name() << item.get_power() << std::endl;
      }
    std::cout << "Knights:" << std::endl;
    for (const auto& item: knights) {
        std::cout << item.get_name() << item.get_power() << std::endl;
      }
    std::cout << "Padawans:" << std::endl;
    for (const auto& item: padawans) {
        std::cout << item.get_name() << item.get_power() << std::endl;
      }
    std::cout << std::endl;
  }

  bool is_member(const Jedi& j) {
    for (const auto& item: masters) {
      if (j.get_name() == item.get_name())
        {
          return true;
        }
      }
    for (const auto& item: knights) {
        if (j.get_name() == item.get_name())
        {
          return true;
        }
      }
    for (const auto& item: padawans) {
        if (j.get_name() == item.get_name())
        {
          return true;
        }
      }
    return false;
  }


  std::string strongest(const std::string& rank) {
    std::string theStrongest = "noone";
    int max_value = 0;

    if (rank == "Master")
    {
      for (const auto& item: masters) {
      if (item.get_power() > max_value)
        {
          max_value = item.get_power();
          theStrongest = item.get_name();
        }
      }
      return theStrongest;
    }
    else if (rank == "Knight")
    {
      for (const auto& item: knights) {
      if (item.get_power() > max_value)
        {
          max_value = item.get_power();
          theStrongest = item.get_name();
        }
      }
      return theStrongest;
    }
    else
    {
      for (const auto& item: padawans) {
      if (item.get_power() > max_value)
        {
          max_value = item.get_power();
          theStrongest = item.get_name();
        }
      }
      return theStrongest;
    }
  }


private:
  std::vector<Jedi> masters;
  std::vector<Jedi> knights;
  std::vector<Jedi> padawans;
};

int main()
{
  int death_star_power = 4;


  // - Készítsünk egy Jedi osztályt, ami egy jedi nevét, rangját és erejét
  // tárolja el (std::string name, std::string rank, int power). Készítsünk
  // lekérdező műveleteket is az adattagokhoz (get_name(), get_rank(),
  // get_power()).

  Jedi j1("Anakin", "Knight", 15);
  Jedi j2("Obiwan", "Knight", 14);
  Jedi j3("Ashoka", "Padawan", 10);
  Jedi j4("Yoda", "Master", 25);


  if (j1.get_power() == 15)
  {
    death_star_power -= j1.get_power() - j2.get_power();
  }



  // - Készítsünk egy JediCouncil osztályt, ami a jedi tanácsot reprezentálja.
  // Ebben tároljuk el a jedi tagokat rangjuk szerint. Egy ranghoz több jedi
  // is tartozhat.
  // - Készítsünk műveletet, amivel a jedi tanácshoz hozzárendelhetünk újabb
  // jediket (add). Ekkor a jedi ereje 10-zel megnő.
  // - Készítsünk egy member_number() függvényt, ami megadja, hogy hány adott
  // rangú jedi van a tanácsban.

  JediCouncil council;
  council.add(j1);
  council.add(j2);
  council.add(j3);
  council.add(j4);


  if (j2.get_power() == 24)
  {
    death_star_power -= council.member_number("Padawan");
  }	



  // - Készítsünk egy tagfüggvényt a jedi tanács osztályhoz, amivel kiírhatjuk
  // a képernyőre a tanács tagjait.
  // - Készítsünk egy is_member() tagfüggvényt, amivel eldönthetjük, hogy egy
  // adott jedi tagja-e a tanácsnak.
  // - Módosítsuk az add() függvényt úgy, hogy amikor Anakin nevű jedit adunk
  // hozzá, akkor kerüljön be a tanácsba, de a rangja csak 5-tel emelkedjen.

  council.print();
  if (council.is_member(j1) && j1.get_power() == 20 &&
      council.is_member(j2) && j2.get_power() == 24)
  {
    death_star_power -= 1;
  }



  // - Készítsünk egy tagfüggvényt a jedi tanács osztályhoz, ami megadja a
  // legerősebb, adott rangú jedi nevét.

  if (council.strongest("Knight") == "Obiwan")
  {
    death_star_power -= 1;
  }


  std::cout
    << "Az eddig elért érdemjegy: "
    << 5 - death_star_power
    << std::endl;

  return 0;
}
