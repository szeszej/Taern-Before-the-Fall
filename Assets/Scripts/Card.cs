using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public string image;
    public string description;
    public int attack;
    public int hp;
    public int cost;
    public int speed;
    public Sprite spriteImage;

    public Card() { }

    public Card(int Id, string CardName, string Image, string Description, int Attack, int Hp, int Cost, int Speed, Sprite SpriteImage)
    {
        id = Id;
        cardName = CardName;
        image = Image;
        description = Description;
        attack = Attack;
        hp = Hp;
        cost = Cost;
        speed = Speed;
        spriteImage = SpriteImage;
    }

    public Card Clone()
    {
        return new Card(this.id, this.cardName, this.image, this.description, this.attack, this.hp, this.cost, this.speed, this.spriteImage);
    }

}