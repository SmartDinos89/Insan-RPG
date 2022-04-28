-> Choices

=== Choices ===
Hey, how are you?
    + [I'm Good]
        -> Good
    + [Not so well]
        -> Bad
    + [What was that?]
        -> Repeat
        
== Good ==
x
That's Great! You should head down to the city, there is an assembly there today.
Bye!
-> END
== Bad ==
x
That's Unfortunate. But, you need to go to the city, the King has called all the adventurers there today.
See you later.
-> END
== Repeat ==
x
I said,
-> Choices
