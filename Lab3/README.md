dirichletProblem
================

#3 вариант

du(x,y) = -f(x,y) , xe(a,b), ye(c,d) <br>
a = -1, b = 1, c = -1, d = 1 <br>
u(a,y) = 1 - y^2 ,  u(b,y) = (1-y^2)*exp(y) <br>
u(x,c) = 1 - x^2 ,  u(x,d) = 1 - x^2 <br>
f(x,y) =|x^2 - y^2| <br>

Точное решение <br>
u(x,y) = exp(1-x^2-y^2)
