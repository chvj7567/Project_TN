## 요구 사항
- .NET 9.0 SDK
- MariaDB 서버
- Redis 서버

## API 엔드포인트

### 인증
- POST /api/auth/register - 회원 가입
- POST /api/auth/login - 로그인
- POST /api/auth/logout - 로그아웃

### 카드
- GET /api/card/list - 모든 카드 목록 조회
- GET /api/card/user - 사용자의 카드 목록 조회
- POST /api/card/deck/update - 사용자 덱 업데이트

### 전투
- POST /api/battle/start - 전투 시작
- POST /api/battle/end - 전투 종료

## 인증 헤더
```
X-User-Id: 사용자 ID
X-Session-Id: 로그인 시 받은 세션 ID
``` 