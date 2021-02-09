# VendingMachine

## Class: VendingMachine
Adds Items to the dictionary
Updates inventory when items are added or bought
Handles money using MoneyHandler class
Uses Logger to log actions (information, warning, error)

## Class: Item
Abstract class containing basic properties and methods for any item used in Vending Machine

## Class: Food
Derived from Item class
Has additional property weight

## Class: Drink
Derived from Item class
Has additional property healing

## Class: Weapon
Derived from Item class
Has additional property damage

## Class: MoneyHandler
Keeps record of money in Vending Machine

## Class: Logger
implements ILogger interface
