using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    private int id;
    private string cardName;
    private string image;
    private string description;
    private int attack;
    private int hp;
    private int cost;
    private int speed;
    private Sprite spriteImage;

    public string CardName { get => cardName; set => cardName = value; }
    public string Image { get => image; set => image = value; }
    public string Description { get => description; set => description = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Cost { get => cost; set => cost = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Id { get => id; set => id = value; }
    public Sprite SpriteImage { get => spriteImage; set => spriteImage = value; }

    public Card() { }

    public Card(int Id, string CardName, string Image, string Description, int Attack, int Hp, int Cost, int Speed, Sprite SpriteImage) {
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
}