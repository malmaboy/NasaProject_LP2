## Nasa Project LP2

### Autores 

- Hugo Carvalho Nº 21901624
- André Figueira Nº 21901435
- João Matos Nº 21901219

</br>

- Hugo Carvalho

    - Classe Planet
    - Class ReadArgs
    - Filter Class
    - BugFixes

- André Figueira 

    - Planet Read BugFixes
    - Star Search
    - UI e Filter bugFixes


- João Matos 

    - Classe Star
    - Classe User Interface
    - BugFixes

### Arquitetura da Solução 

- No início do projeto, começámos por implementar a classe `FileReader` e `Planet`, em que na classe `FileReader` é feita a leitura do ficheiro e dos argumentos inseridos pelo utilizador. Na classe `Planet` estão presentes todos os parâmetros possíveis que podem ser utilizados para obter informações sobre os planetas. De seguida, implementámos a classe `Filter` cujo objetivo é filtrar os argumentos dados pelo utilizador e devolver as informações dos mesmos. A classe `User Interface` recebe o argumentos dados pelo utilizador, e imprime os dados e erros caso o utilizador insira argumentos inválidos ou localizações inválidas. Durante o projeto apagámos a classe  `ReadArgs`, pois esta era idêntica à `User Interface`.

  - As Relações entre as classes estão demonstradas no diagrama UML seguinte:
![diagrama](NasaProjectDiagram.png)

### Observações

Durante o projeto tivemos várias dificuldades em definir o tipo dos valores lidos (int, float, string,...) e por consequência alterámos várias vezes a forma como eram lidos os valores. 

<br>  

---

<br>

## [Link para repositorio](https://github.com/malmaboy/NasaProject_LP2)