# Docker Compose Commands

## Development
```bash
# Start development environment
docker-compose up --build

# Start without build
docker-compose up

# Start in background
docker-compose up -d

# View logs
docker-compose logs -f portfolio-web

# Stop development environment
docker-compose down