# Déplacement du joueur

Les déplacements horizontaux et verticaux sont calculé en récupérent l'axe verticale et horizontale,  
qu'on multiplie par une vitesse de travaille, ce qui donne des variable qu'on peut transmettre à une fonction.

```
horizontalInput = Input.GetAxis("Horizontal") * workingSpeed;
depthInput = Input.GetAxis("Vertical") * workingSpeed;

PlayerMovements(horizontalInput, depthInput);
```
\
Dans cette fonction on va calculer les mouvements par rapport au sens de la caméra.  
En récupérent le vector3 forward et right, du transform de la camera orbitale, en remettant à 0 l'axe y des deux vecteur.  

```
Vector3 camforward = orbitCamera.transform.forward;
Vector3 camRight = orbitCamera.transform.right;

camforward.y = 0;
camRight.y = 0;
```
\
Ensuite on on crée deux nouveaux Vector3 (forwardRelative et rightRelative).  
Qui sont calculer en multipliant respectivement:  
la valeur de profondeur par la variable camforward,  
la valeur horizontale par la variable camRight.

```
Vector3 forwardRelative = _depth * camforward;
Vector3 rightRelative = _horizontale * camRight;
```
\
Qu'on ajoute ensuite dans un nouveau Vector3 nommer moveDir ce qui permet de gérer les déplacement plus facilement.

```
Vector3 moveDir = forwardRelative + rightRelative;
```
\
On ajoute ensuite en partie le vecteur à la vélocité du Rigidbody comme montré ci-dessous

```
rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
```

Et si la vélocité n'est pas à 0, alors on va faire avancer le joueur avec cette ligne:

```
if (rb.velocity != Vector3.zero)
    transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
```
