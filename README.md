# API servico-curso-api
A API de Busca de Cursos fornece endpoints para consultar informações sobre cursos disponíveis no sistema. Abaixo estão listados os principais endpoints, suas funcionalidades e os parâmetros aceitos.

**Endpoints**
# GET /cursos/GetByTeacherId**
Este endpoint retorna uma lista de cursos associados a um professor específico, identificado pelo seu ID.

Parâmetros
teacherId (obrigatório): O ID do professor cujos cursos serão buscados.
Exemplo de Requisição

GET https://api.busca-cursos.com/v1/cursos/GetByTeacherId?teacherId=12345

# GET /cursos/GetAllAsync
Este endpoint retorna uma lista de todos os cursos existentes no sistema.

Exemplo de Requisição
GET https://api.busca-cursos.com/v1/cursos/GetAllAsync

# GET /cursos/GetAsync
Este endpoint retorna informações detalhadas de um curso específico, identificado pelo seu ID.

Parâmetros
courseId (obrigatório): O ID do curso a ser buscado.

Exemplo de Requisição
GET https://api.busca-cursos.com/v1/cursos/GetAsync?courseId=course-1
