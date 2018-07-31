# MtG Aggro Simulator

This project aims to implement a very simple "aggro deck simulator", in which a deck is fed to the
application and it runs through a series of mock games with no opponent to gather statistics.

Example statistics I think I can be useful are:

## For each round ...

* ... how much mana is available?
* ... how much damage can I dish out?
* ... how much extra mana do I have available (that is, unused mana at the end of the round)?
* ... how much cards do I have in my hand that I could not cast?

## For each card ...

* ... what is the earliest round I can cast it?
* ... how many times did I draw it?
* ... how many times did I play it at all?