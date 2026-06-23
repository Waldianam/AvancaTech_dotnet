const links = document.querySelectorAll(".navbar li a");

links.forEach(link =>{
    link.addEventListener("click", ()=>{

        //Removendo o Active de todo os link
        links.forEach( l => l.classList.remove("active"));

        //adicionando o Active para o Item clicado
        link.classList.add("active");

    });
});