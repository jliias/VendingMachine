# VendingMachine

**VendingMachineLibrary** : class library of VendingMachine

**VendingMachineLibraryTests** : unit tests for VendingMachineLibrary

**VendingConsole** : Simple example app using VendingMachineLibrary (not polished, just for testing purposes)


## Class: VendingMachine
Adds Items to the dictionary. Updates inventory when items are added or bought. Handles money using MoneyHandler class. Uses Logger to log actions (information, warning, error).

Public methods:
- Add item to Catalog:  *public void AddItem(string key, Item newItem)*
- Buy item:  *public string BuyItem(string key)*
- Get catalog containing all items:  *public Dictionary<string, Item> GetItems()*

## Abstract class: Item
Abstract class containing basic properties and methods for any item used in Vending Machine

Public Methods:
- Get item name:  *public string GetName()*
- Get item price:  *public decimal GetPrice()*
- Get remaining number of these items:  *public decimal GetRemaining()*
- Remove one piece of items:  *public bool RemoveItem()*

## Class: Food
Derived from Item class. Has additional property *weight*.

## Class: Drink
Derived from Item class. Has additional property *healing*.

## Class: Weapon
Derived from Item class. Has additional property *damage*.

## Class: MoneyHandler
Keeps record of money in Vending Machine

Public methods:
- Feed money to machine:  *public void FeedMoney(decimal amount)*
- Remove money from machine:  *public bool RemoveMoney(decimal amount)*
- How much money is left:  *public decimal moneyEntered { get; private set; }* 

## Interface: ILogger ##
Interface for Logger class(es)

*void Log(int level, string msg);*

## Class: Logger
implements ILogger interface

Two alternatives for Log Method:
- Without severity level:  *public void Log(string msg)*
- With severity level:  *public void Log(int level, string msg)*

Severity levels:

0. TRACE
1. DEBUG
2. INFORMATION
3. WARNING
4. ERROR
5. CRITICAL


